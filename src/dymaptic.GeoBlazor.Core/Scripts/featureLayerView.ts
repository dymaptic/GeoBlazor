import FeatureLayerViewGenerated from './featureLayerView.gb';
import Query from '@arcgis/core/rest/support/Query';
import {DotNetQuery} from './definitions';
import {getProtobufGraphicStream, hasValue, graphicsRefs, lookupJsGraphicById} from './arcGisJsInterop';

export default class FeatureLayerViewWrapper extends FeatureLayerViewGenerated {
    
    constructor(component) {
        super(component);
    }

    async setFeatureEffect(dnfeatureEffect): Promise<void> {
        let {buildJsFeatureEffect} = await import('./featureEffect');
        this.component.featureEffect = await buildJsFeatureEffect(dnfeatureEffect, this.layerId, this.viewId);
    }

    async setFilter(dnDeatureFilter): Promise<void> {
        let {buildJsFeatureFilter} = await import('./featureFilter');
        this.component.filter = await buildJsFeatureFilter(dnDeatureFilter, this.layerId, this.viewId);
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

    highlight(target: any): any {
        return this.component.highlight(target);
    }

    highlightByGeoBlazorId(geoBlazorId: string): any {
        let graphic = lookupJsGraphicById(geoBlazorId, this.layerId, this.viewId);
        if (hasValue(graphic)) {
            return this.component.highlight(graphic!);
        }
        
        return null;
    }

    highlightByGeoBlazorIds(geoBlazorIds: string[]): any {
        let graphics : any[] = [];
        geoBlazorIds.forEach(i => {
            let graphic = lookupJsGraphicById(i, this.layerId, this.viewId);
            if (hasValue(graphic)) {
                graphics.push(graphic);
            }
        });
        if (graphics.length === 0) {
            return null;
        }
        return this.component.highlight(graphics);
    }

    async queryExtent(query: DotNetQuery, options: any): Promise<any> {
        let {buildJsQuery} = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId);
        let result = await this.component.queryExtent(jsQuery, options);
        return {
            count: result.count,
            extent: result.extent
        };
    }

    async queryFeatureCount(query: DotNetQuery, options: any): Promise<number> {
        let {buildJsQuery} = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId);
        return await this.component.queryFeatureCount(jsQuery, options);
    }

    async queryFeatures(query: DotNetQuery, options: any, dotNetRef: any, queryId: string)
        : Promise<any | null> {
        try {
            let jsQuery: Query | undefined = undefined;
            let {buildJsQuery} = await import('./query');

            if (hasValue(query)) {
                jsQuery = await buildJsQuery(query, this.layerId, this.viewId);
            }

            let featureSet = await this.component.queryFeatures(jsQuery, options);
            let {buildDotNetFeatureSet} = await import('./featureSet');

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

    async queryObjectIds(query: DotNetQuery, options: any): Promise<string[]> {
        let {buildJsQuery} = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId);
        let objectIds = await this.component.queryObjectIds(jsQuery, options);
        return objectIds;
    }

}


export async function buildJsFeatureLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureLayerViewGenerated} = await import('./featureLayerView.gb');
    return await buildJsFeatureLayerViewGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureLayerView(jsObject: any): Promise<any> {
    let {buildDotNetFeatureLayerViewGenerated} = await import('./featureLayerView.gb');
    return await buildDotNetFeatureLayerViewGenerated(jsObject);
}
