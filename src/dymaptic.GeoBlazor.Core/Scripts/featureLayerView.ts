import Query from '@arcgis/core/rest/support/Query';
import { DotNetQuery } from './definitions';
import {buildJsFeatureFilter, getProtobufGraphicStream, hasValue, lookupGeoBlazorId} from './arcGisJsInterop';
import FeatureLayerViewGenerated from "./featureLayerView.gb";

export default class FeatureLayerViewWrapper extends FeatureLayerViewGenerated {
    private geoBlazorLayerId: string | null = null;

    constructor(component) {
        super(component);
        // set all properties from featureLayerView
        for (let prop in component) {
            if (component.hasOwnProperty(prop)) {
                this[prop] = component[prop];
            }
        }
        this.geoBlazorLayerId = lookupGeoBlazorId(this.component.layer);
    }

    unwrap() {
        return this.component;
    }
    async setFeatureEffect(dnfeatureEffect): Promise<void> {
        let { buildJsFeatureEffect } = await import('./jsBuilder');
        this.component.featureEffect = buildJsFeatureEffect(dnfeatureEffect);
    }

    setFilter(dnDeatureFilter): void {
        this.component.filter = buildJsFeatureFilter(dnDeatureFilter);
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

    async queryExtent(query: DotNetQuery, options: any): Promise<any> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId);
        let result = await this.component.queryExtent(jsQuery, options);
        return {
            count: result.count,
            extent: result.extent
        };
    }

    async queryFeatureCount(query: DotNetQuery, options: any): Promise<number> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId);
        return await this.component.queryFeatureCount(jsQuery, options);
    }

    async queryFeatures(query: DotNetQuery, options: any, dotNetRef: any, viewId: string | null, queryId: string)
        : Promise<any | null> {
        try {
            let jsQuery: Query | undefined = undefined;
            let { buildJsQuery } = await import('./query');

            if (hasValue(query)) {
                jsQuery = await buildJsQuery(query, this.layerId, this.viewId);
            }

            let featureSet = await this.component.queryFeatures(jsQuery, options);
            let { buildDotNetFeatureSet } = await import('./featureSet');

            let dotNetFeatureSet = await buildDotNetFeatureSet(featureSet, this.geoBlazorLayerId, viewId);
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
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId);
        return await this.component.queryObjectIds(jsQuery, options);
    }

    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
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
