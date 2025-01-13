import FeatureLayerView from "@arcgis/core/views/layers/FeatureLayerView";
import Query from "@arcgis/core/rest/support/Query";
import {
    DotNetFeatureEffect,
    DotNetFeatureFilter,
    DotNetFeatureSet,
    DotNetQuery,
    IPropertyWrapper
} from "./definitions";
import {buildJsFeatureEffect, buildJsFeatureFilter, buildJsQuery} from "./jsBuilder";
import {getProtobufGraphicStream, graphicsRefs, hasValue} from "./arcGisJsInterop";
import {
    buildDotNetFeatureSet
} from "./dotNetBuilder";
import FeatureEffect from "@arcgis/core/layers/support/FeatureEffect";
import FeatureFilter from "@arcgis/core/layers/support/FeatureFilter";
import Handle = __esri.Handle;
import Graphic from "@arcgis/core/Graphic";

export default class FeatureLayerViewWrapper implements IPropertyWrapper {
    private featureLayerView: FeatureLayerView;

    constructor(component: FeatureLayerView) {
        this.featureLayerView = component;
        // set all properties from featureLayerView
        for (let prop in component) {
            if (component.hasOwnProperty(prop)) {
                this[prop] = component[prop];
            }
        }
    }

    unwrap() {
        return this.featureLayerView;
    }
    setFeatureEffect(dnfeatureEffect: DotNetFeatureEffect): any {
        this.featureLayerView.featureEffect = buildJsFeatureEffect(dnfeatureEffect) as FeatureEffect;
        return this.featureLayerView.featureEffect;
    }

    setFilter(dnDeatureFilter: DotNetFeatureFilter): any {
        this.featureLayerView.filter = buildJsFeatureFilter(dnDeatureFilter) as FeatureFilter;
        return this.featureLayerView.filter;
    }

    setMaximumNumberOfFeatures(maximumNumberOfFeatures: number): void {
        this.featureLayerView.maximumNumberOfFeatures = maximumNumberOfFeatures;
    }

    createAggregateQuery(): Query {
        return this.featureLayerView.createAggregateQuery();
    }

    createQuery(): Query {
        return this.featureLayerView.createQuery();
    }

    highlight(target: any): Handle {
        return this.featureLayerView.highlight(target);
    }
    
    highlightByGeoBlazorId(geoBlazorId: string): Handle | null {
        if (!graphicsRefs.hasOwnProperty(geoBlazorId)) {
            return null;
        }
        let graphic = graphicsRefs[geoBlazorId] as Graphic;
        return this.featureLayerView.highlight(graphic);
    }
    
    highlightByGeoBlazorIds(geoBlazorIds: string[]): Handle | null {
        let graphics : Graphic[] = [];
        geoBlazorIds.forEach(i => {
            if (graphicsRefs.hasOwnProperty(i)) {
                graphics.push(graphicsRefs[i] as Graphic);
            }
        });
        if (graphics.length === 0) {
            return null;
        }
        return this.featureLayerView.highlight(graphics);
    }

    async queryExtent(query: DotNetQuery, options: any): Promise<any> {
        let jsQuery = buildJsQuery(query);
        let result = await this.featureLayerView.queryExtent(jsQuery, options);
        return {
            count: result.count,
            extent: result.extent
        };
    }

    async queryFeatureCount(query: DotNetQuery, options: any): Promise<number> {
        let jsQuery = buildJsQuery(query);
        return await this.featureLayerView.queryFeatureCount(jsQuery, options);
    }

    async queryFeatures(query: DotNetQuery, options: any, dotNetRef: any, viewId: string | null, queryId: string)
        : Promise<DotNetFeatureSet | null> {
        try {
            let jsQuery: Query | undefined = undefined;

            if (hasValue(query)) {
                jsQuery = buildJsQuery(query as DotNetQuery);
            }

            let featureSet = await this.featureLayerView.queryFeatures(jsQuery, options);

            let dotNetFeatureSet = await buildDotNetFeatureSet(featureSet, viewId);
            if (dotNetFeatureSet.features.length > 0) {
                let graphics = getProtobufGraphicStream(dotNetFeatureSet.features, this.featureLayerView.layer);
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
        return await this.featureLayerView.queryObjectIds(jsQuery, options);
    }

    setProperty(prop: string, value: any): void {
        this.featureLayerView[prop] = value;
    }

    getProperty(prop: string) {
        return this.featureLayerView[prop];
    }

    addToProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.featureLayerView[prop].addMany(value);
        } else {
            this.featureLayerView[prop].add(value);
        }
    }

    removeFromProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.featureLayerView[prop].removeMany(value);
        } else {
            this.featureLayerView[prop].remove(value);
        }
    }
}