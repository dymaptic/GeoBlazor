// override generated code in this file
import GeoRSSLayerGenerated from './geoRSSLayer.gb';
import GeoRSSLayer from '@arcgis/core/layers/GeoRSSLayer';

export default class GeoRSSLayerWrapper extends GeoRSSLayerGenerated {

    constructor(layer: GeoRSSLayer) {
        super(layer);
    }
    
}              
export async function buildJsGeoRSSLayer(dotNetObject: any): Promise<any> {
    let { buildJsGeoRSSLayerGenerated } = await import('./geoRSSLayer.gb');
    return await buildJsGeoRSSLayerGenerated(dotNetObject);
}
export async function buildDotNetGeoRSSLayer(jsObject: any): Promise<any> {
    let { buildDotNetGeoRSSLayerGenerated } = await import('./geoRSSLayer.gb');
    return await buildDotNetGeoRSSLayerGenerated(jsObject);
}
