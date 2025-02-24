// override generated code in this file
import IOrderedLayerGenerated from './iOrderedLayer.gb';
import OrderedLayer = __esri.OrderedLayer;

export default class IOrderedLayerWrapper extends IOrderedLayerGenerated {

    constructor(layer: OrderedLayer) {
        super(layer);
    }

}

export async function buildJsIOrderedLayer(dotNetObject: any): Promise<any> {
    let {buildJsIOrderedLayerGenerated} = await import('./iOrderedLayer.gb');
    return buildJsIOrderedLayerGenerated(dotNetObject);
}

export async function buildDotNetIOrderedLayer(jsObject: any): Promise<any> {
    let {buildDotNetIOrderedLayerGenerated} = await import('./iOrderedLayer.gb');
    return await buildDotNetIOrderedLayerGenerated(jsObject);
}
