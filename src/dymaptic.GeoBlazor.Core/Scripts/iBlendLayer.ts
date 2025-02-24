// override generated code in this file
import IBlendLayerGenerated from './iBlendLayer.gb';
import BlendLayer = __esri.BlendLayer;

export default class IBlendLayerWrapper extends IBlendLayerGenerated {

    constructor(layer: BlendLayer) {
        super(layer);
    }

}

export async function buildJsIBlendLayer(dotNetObject: any): Promise<any> {
    let {buildJsIBlendLayerGenerated} = await import('./iBlendLayer.gb');
    return buildJsIBlendLayerGenerated(dotNetObject);
}

export async function buildDotNetIBlendLayer(jsObject: any): Promise<any> {
    let {buildDotNetIBlendLayerGenerated} = await import('./iBlendLayer.gb');
    return await buildDotNetIBlendLayerGenerated(jsObject);
}
