// override generated code in this file
import GeoJSONLayerGenerated from './geoJSONLayer.gb';
import GeoJSONLayer from '@arcgis/core/layers/GeoJSONLayer';

export default class GeoJSONLayerWrapper extends GeoJSONLayerGenerated {

    constructor(layer: GeoJSONLayer) {
        super(layer);
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
