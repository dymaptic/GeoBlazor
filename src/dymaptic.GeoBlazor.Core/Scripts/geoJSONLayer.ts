// override generated code in this file
import Query from "@arcgis/core/rest/support/Query";
import GeoJSONLayerGenerated from './geoJSONLayer.gb';
import GeoJSONLayer from '@arcgis/core/layers/GeoJSONLayer';
import {buildEncodedJson, getProtobufGraphicStream, hasValue} from './geoBlazorCore';
import {DotNetFeatureSet, DotNetQuery} from "./definitions";
import {buildDotNetQuery} from "./query";

export default class GeoJSONLayerWrapper extends GeoJSONLayerGenerated {

    constructor(layer: GeoJSONLayer) {
        super(layer);
    }

    async createQuery(): Promise<DotNetQuery> {
        let jsQuery = this.layer.createQuery();
        return await buildDotNetQuery(jsQuery, this.viewId);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetGeoJSONLayer(result, this.viewId);
        return buildEncodedJson(dotNetLayer);
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
    async getTemplates(): Promise<any> {
        if (!hasValue(this.layer.templates)) {
            return null;
        }

        let { buildDotNetIFeatureTemplate } = await import('./iFeatureTemplate');
        return await Promise.all(this.layer.templates!.map(async i => await buildDotNetIFeatureTemplate(i)));
    }

    async setTemplates(value: any): Promise<void> {
        let { buildJsIFeatureTemplate } = await import('./iFeatureTemplate');
        this.layer.templates = await Promise.all(value.map(async i => await buildJsIFeatureTemplate(i))) as any;
    }

    async queryFeatures(query: DotNetQuery | null, signal: AbortSignal):
        Promise<DotNetFeatureSet | null> {
        let jsQuery: Query | null = null;
        if (hasValue(query)) {
            let { buildJsQuery} = await import('./query');
            jsQuery = buildJsQuery(query) as Query;
        }

        let featureSet = await this.layer.queryFeatures(jsQuery, { signal: signal });

        let {buildDotNetFeatureSet} = await import('./featureSet');
        return await buildDotNetFeatureSet(featureSet, this.geoBlazorId, this.viewId);
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
}

let proGeoJSONLayerIds: any[] = [];

export async function buildJsGeoJSONLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (dotNetObject.type === 'pro-geojson') {
        proGeoJSONLayerIds.push(dotNetObject.id);
    }
    
    if (!hasValue(dotNetObject.url) && hasValue(dotNetObject.sourceJSON)) {
        const blob = new Blob([dotNetObject.sourceJSON], { type: "application/json" });
        dotNetObject.url = URL.createObjectURL(blob);
    }
    
    let {buildJsGeoJSONLayerGenerated} = await import('./geoJSONLayer.gb');
    return await buildJsGeoJSONLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGeoJSONLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetGeoJSONLayerGenerated} = await import('./geoJSONLayer.gb');
    let dnGeoJSONLayer = await buildDotNetGeoJSONLayerGenerated(jsObject, viewId);
    if (hasValue(dnGeoJSONLayer.id) && proGeoJSONLayerIds.includes(dnGeoJSONLayer.id)) {
        dnGeoJSONLayer.type = 'pro-geojson';
    }
    
    return dnGeoJSONLayer;
}
