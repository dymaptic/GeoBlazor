import UnsupportedLayer from '@arcgis/core/layers/UnsupportedLayer';
import IUnsupportedLayerGenerated from './iUnsupportedLayer.gb';

export default class IUnsupportedLayerWrapper extends IUnsupportedLayerGenerated {

    constructor(layer: UnsupportedLayer) {
        super(layer);
    }
    
}

export async function buildJsIUnsupportedLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIUnsupportedLayerGenerated } = await import('./iUnsupportedLayer.gb');
    return await buildJsIUnsupportedLayerGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetIUnsupportedLayer(jsObject: any): Promise<any> {
    let { buildDotNetIUnsupportedLayerGenerated } = await import('./iUnsupportedLayer.gb');
    return await buildDotNetIUnsupportedLayerGenerated(jsObject);
}
