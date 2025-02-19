// override generated code in this file
import IBlendLayerGenerated from './iBlendLayer.gb';
import BlendLayer = __esri.BlendLayer;

export default class IBlendLayerWrapper extends IBlendLayerGenerated {

    constructor(layer: BlendLayer) {
        super(layer);
    }
    
}

export async function buildJsIBlendLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIBlendLayerGenerated } = await import('./iBlendLayer.gb');
    return await buildJsIBlendLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIBlendLayer(jsObject: any): Promise<any> {
    let { buildDotNetIBlendLayerGenerated } = await import('./iBlendLayer.gb');
    return await buildDotNetIBlendLayerGenerated(jsObject);
}
