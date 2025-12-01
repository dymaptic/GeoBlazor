// override generated code in this file
import WFSLayerGenerated from './wFSLayer.gb';
import WFSLayer from '@arcgis/core/layers/WFSLayer';
import {buildEncodedJson, hasValue} from "./geoBlazorCore";
import Query from "@arcgis/core/rest/support/Query";
import {DotNetQuery} from "./definitions";
import {buildDotNetQuery} from "./query";

export default class WFSLayerWrapper extends WFSLayerGenerated {

    constructor(layer: WFSLayer) {
        super(layer);
    }

    async createQuery(): Promise<DotNetQuery> {
        let jsQuery = this.layer.createQuery();
        return await buildDotNetQuery(jsQuery, this.viewId);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetWFSLayer(result, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }

    async queryExtent(query: any,
                      options: any): Promise<any> {
        let jsQuery: Query | null = null;
        if (hasValue(query)) {
            let { buildJsQuery} = await import('./query');
            jsQuery = buildJsQuery(query) as Query;
        }
        return await this.layer.queryExtent(jsQuery,
            options);
    }

    async queryFeatureCount(query: any,
                            options: any): Promise<any> {
        let jsQuery: Query | null = null;
        if (hasValue(query)) {
            let { buildJsQuery} = await import('./query');
            jsQuery = buildJsQuery(query) as Query;
        }
        return await this.layer.queryFeatureCount(jsQuery,
            options);
    }

    async queryFeatures(query: any,
                        options: any): Promise<any> {
        let jsQuery: Query | null = null;
        if (hasValue(query)) {
            let { buildJsQuery} = await import('./query');
            jsQuery = buildJsQuery(query) as Query;
        }
        return await this.layer.queryFeatures(jsQuery,
            options);
    }

    async queryObjectIds(query: any,
                         options: any): Promise<any> {
        let jsQuery: Query | null = null;
        if (hasValue(query)) {
            let { buildJsQuery} = await import('./query');
            jsQuery = buildJsQuery(query) as Query;
        }
        return await this.layer.queryObjectIds(jsQuery,
            options);
    }

    async getFeatureReduction(): Promise<any> {
        try {
            let jsFeatureReduction = this.layer.featureReduction;
            let { buildDotNetIFeatureReduction } = await import('./iFeatureReduction');
            return await buildDotNetIFeatureReduction(jsFeatureReduction, this.viewId);
        } catch (error) {
            throw new Error("Available only in GeoBlazor Pro. " + error);
        }
    }
    
    async setFeatureReduction(featureReduction: any) {
        let { buildJsIFeatureReduction } = await import('./iFeatureReduction');
        let jsFeatureReduction = await buildJsIFeatureReduction(featureReduction, this.layerId, this.viewId);
        this.layer.featureReduction = jsFeatureReduction;
    }

    async setSpatialReference(spatialReference: any): Promise<void> {
        let {buildJsSpatialReference} = await import('./spatialReference');
        this.layer.spatialReference = buildJsSpatialReference(spatialReference) as any;
    }
}

export async function buildJsWFSLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWFSLayerGenerated} = await import('./wFSLayer.gb');
    // simplify the object, it might have been loaded from the server and contain stuff that will break
    delete dotNetObject.wfsCapabilities;
    return await buildJsWFSLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWFSLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetWFSLayerGenerated} = await import('./wFSLayer.gb');
    return await buildDotNetWFSLayerGenerated(jsObject, viewId);
}
