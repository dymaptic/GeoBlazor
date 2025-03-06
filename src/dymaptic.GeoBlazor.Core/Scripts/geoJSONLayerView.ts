// override generated code in this file
import GeoJSONLayerViewGenerated from './geoJSONLayerView.gb';
import GeoJSONLayerView from '@arcgis/core/views/layers/GeoJSONLayerView';

export default class GeoJSONLayerViewWrapper extends GeoJSONLayerViewGenerated {

    constructor(component: GeoJSONLayerView) {
        super(component);
    }
    
}

export async function buildJsGeoJSONLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeoJSONLayerViewGenerated } = await import('./geoJSONLayerView.gb');
    return await buildJsGeoJSONLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeoJSONLayerView(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetGeoJSONLayerViewGenerated } = await import('./geoJSONLayerView.gb');
    return await buildDotNetGeoJSONLayerViewGenerated(jsObject, layerId, viewId);
}
