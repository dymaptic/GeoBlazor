// override generated code in this file
import WebTileLayerGenerated from './webTileLayer.gb';
import WebTileLayer from '@arcgis/core/layers/WebTileLayer';

export default class WebTileLayerWrapper extends WebTileLayerGenerated {

    constructor(layer: WebTileLayer) {
        super(layer);
    }
    
}              
export async function buildJsWebTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebTileLayerGenerated } = await import('./webTileLayer.gb');
    return await buildJsWebTileLayerGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetWebTileLayer(jsObject: any): Promise<any> {
    let { buildDotNetWebTileLayerGenerated } = await import('./webTileLayer.gb');
    return await buildDotNetWebTileLayerGenerated(jsObject);
}
