import FeatureLayerViewGenerated from './featureLayerView.gb';
import FeatureLayerView from "@arcgis/core/views/layers/FeatureLayerView";
import Query from "@arcgis/core/rest/support/Query";
import {
    DotNetFeatureEffect,
    DotNetFeatureFilter,
    DotNetFeatureSet,
    DotNetQuery
} from "./definitions";
import {buildJsFeatureEffect, buildJsFeatureFilter, buildJsQuery} from "./jsBuilder";
import {getProtobufGraphicStream, graphicsRefs, hasValue} from "./arcGisJsInterop";
import FeatureEffect from "@arcgis/core/layers/support/FeatureEffect";
import FeatureFilter from "@arcgis/core/layers/support/FeatureFilter";
import Handle = __esri.Handle;
import Graphic from "@arcgis/core/Graphic";

export default class FeatureLayerViewWrapper extends FeatureLayerViewGenerated {
    
    constructor(component: FeatureLayerView) {
        super(component);
    }

    setFeatureEffect(dnfeatureEffect: DotNetFeatureEffect): any {
        this.component.featureEffect = buildJsFeatureEffect(dnfeatureEffect) as FeatureEffect;
        return this.component.featureEffect;
    }

    setFilter(dnDeatureFilter: DotNetFeatureFilter): any {
        this.component.filter = buildJsFeatureFilter(dnDeatureFilter) as FeatureFilter;
        return this.component.filter;
    }

    setMaximumNumberOfFeatures(maximumNumberOfFeatures: number): void {
        this.component.maximumNumberOfFeatures = maximumNumberOfFeatures;
    }

    createAggregateQuery(): Query {
        return this.component.createAggregateQuery();
    }

    createQuery(): Query {
        return this.component.createQuery();
    }

    highlight(target: any): Handle {
        return this.component.highlight(target);
    }
    
    highlightByGeoBlazorId(geoBlazorId: string): Handle | null {
        if (!graphicsRefs.hasOwnProperty(geoBlazorId)) {
            return null;
        }
        
        if (graphicsRefs[this.layerId!].hasOwnProperty(geoBlazorId)) {
            let graphic = graphicsRefs[this.layerId!][geoBlazorId];
            return this.component.highlight(graphic);
        }
        
        return null;
    }
    
    highlightByGeoBlazorIds(geoBlazorIds: string[]): Handle | null {
        let graphics : Graphic[] = [];
        let group = graphicsRefs[this.layerId!];
        
        geoBlazorIds.forEach(i => {
            if (group.hasOwnProperty(i)) {
                graphics.push(group[i] as Graphic);
            }
        });
        if (graphics.length === 0) {
            return null;
        }
        return this.component.highlight(graphics);
    }

    async queryExtent(query: DotNetQuery, options: any): Promise<any> {
        let jsQuery = buildJsQuery(query);
        let result = await this.component.queryExtent(jsQuery, options);
        return {
            count: result.count,
            extent: result.extent
        };
    }

    async queryFeatureCount(query: DotNetQuery, options: any): Promise<number> {
        let jsQuery = buildJsQuery(query);
        return await this.component.queryFeatureCount(jsQuery, options);
    }

    async queryFeatures(query: DotNetQuery, options: any, dotNetRef: any, queryId: string)
        : Promise<DotNetFeatureSet | null> {
        try {
            let jsQuery: Query | undefined = undefined;

            if (hasValue(query)) {
                jsQuery = buildJsQuery(query as DotNetQuery);
            }

            let featureSet = await this.component.queryFeatures(jsQuery, options);

            let { buildDotNetFeatureSet } = await import('./featureSet');
            let dotNetFeatureSet = await buildDotNetFeatureSet(featureSet, this.layerId, this.viewId);
            if (dotNetFeatureSet.features.length > 0) {
                let graphics = getProtobufGraphicStream(dotNetFeatureSet.features, this.component.layer);
                await dotNetRef.invokeMethodAsync('OnQueryFeaturesStreamCallback', graphics, queryId);
                dotNetFeatureSet.features = [];
            }

            return dotNetFeatureSet;
        } catch (error) {
            console.debug(error);
            throw error;
        }
    }

    async queryObjectIds(query: DotNetQuery, options: any): Promise<number[]> {
        let jsQuery = buildJsQuery(query);
        return await this.component.queryObjectIds(jsQuery, options);
    }




}
export async function buildJsFeatureLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureLayerViewGenerated } = await import('./featureLayerView.gb');
    return await buildJsFeatureLayerViewGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetFeatureLayerView(jsObject: any): Promise<any> {
    let { buildDotNetFeatureLayerViewGenerated } = await import('./featureLayerView.gb');
    return await buildDotNetFeatureLayerViewGenerated(jsObject);
}
