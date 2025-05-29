// override generated code in this file
import ICIMSymbolLayerGenerated from './iCIMSymbolLayer.gb';
import CIMSymbolLayer = __esri.CIMSymbolLayer;

export default class ICIMSymbolLayerWrapper extends ICIMSymbolLayerGenerated {

    constructor(layer: CIMSymbolLayer) {
        super(layer);
    }

}

export async function buildJsICIMSymbolLayer(dotNetObject: any): Promise<any> {
    let {buildJsICIMSymbolLayerGenerated} = await import('./iCIMSymbolLayer.gb');
    return buildJsICIMSymbolLayerGenerated(dotNetObject);
}

export async function buildDotNetICIMSymbolLayer(jsObject: any): Promise<any> {
    let {buildDotNetICIMSymbolLayerGenerated} = await import('./iCIMSymbolLayer.gb');
    return await buildDotNetICIMSymbolLayerGenerated(jsObject);
}
