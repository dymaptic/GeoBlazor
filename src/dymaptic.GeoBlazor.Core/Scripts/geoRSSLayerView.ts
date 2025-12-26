// override generated code in this file
import GeoRSSLayerViewGenerated from './geoRSSLayerView.gb';
import GeoRSSLayerView from '@arcgis/core/views/layers/GeoRSSLayerView';

export default class GeoRSSLayerViewWrapper extends GeoRSSLayerViewGenerated {

    constructor(component: GeoRSSLayerView) {
        super(component);
    }
    
}

export async function buildJsGeoRSSLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeoRSSLayerViewGenerated } = await import('./geoRSSLayerView.gb');
    return await buildJsGeoRSSLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeoRSSLayerView(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetGeoRSSLayerViewGenerated } = await import('./geoRSSLayerView.gb');
    return await buildDotNetGeoRSSLayerViewGenerated(jsObject, layerId, viewId);
}
