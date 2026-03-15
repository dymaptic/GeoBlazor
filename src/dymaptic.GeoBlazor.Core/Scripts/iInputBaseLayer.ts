// override generated code in this file
import IInputBaseLayerGenerated from './iInputBaseLayer.gb';
import InputBaseLayer = __esri.InputBaseLayer;

export default class IInputBaseLayerWrapper extends IInputBaseLayerGenerated {

    constructor(layer: InputBaseLayer) {
        super(layer);
    }
    
}

export async function buildJsIInputBaseLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIInputBaseLayerGenerated } = await import('./iInputBaseLayer.gb');
    return await buildJsIInputBaseLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIInputBaseLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetIInputBaseLayerGenerated } = await import('./iInputBaseLayer.gb');
    return await buildDotNetIInputBaseLayerGenerated(jsObject, layerId, viewId);
}
