// override generated code in this file
import GeoJSONLayerGenerated from './geoJSONLayer.gb';
import GeoJSONLayer from '@arcgis/core/layers/GeoJSONLayer';

export default class GeoJSONLayerWrapper extends GeoJSONLayerGenerated {

    constructor(layer: GeoJSONLayer) {
        super(layer);
    }

    async getFeatureReduction(): Promise<any> {
        try {
            let jsFeatureReduction = this.layer.featureReduction;
            let { buildDotNetIFeatureReduction } = await import('./iFeatureReduction');
            return await buildDotNetIFeatureReduction(jsFeatureReduction, this.layerId, this.viewId);
        } catch (error) {
            throw new Error("Available only in GeoBlazor Pro. " + error);
        }
    }

    async setFeatureReduction(featureReduction: any) {
        let { buildJsIFeatureReduction } = await import('./iFeatureReduction');
        let jsFeatureReduction = await buildJsIFeatureReduction(featureReduction, this.layerId, this.viewId);
        this.layer.featureReduction = jsFeatureReduction;
    }
}

export async function buildJsGeoJSONLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGeoJSONLayerGenerated} = await import('./geoJSONLayer.gb');
    return await buildJsGeoJSONLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGeoJSONLayer(jsObject: any): Promise<any> {
    let {buildDotNetGeoJSONLayerGenerated} = await import('./geoJSONLayer.gb');
    return await buildDotNetGeoJSONLayerGenerated(jsObject);
}
