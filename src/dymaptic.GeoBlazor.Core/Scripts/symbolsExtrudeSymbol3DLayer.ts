// override generated code in this file
import SymbolsExtrudeSymbol3DLayerGenerated from './symbolsExtrudeSymbol3DLayer.gb';
import symbolsExtrudeSymbol3DLayer = __esri.symbolsExtrudeSymbol3DLayer;

export default class SymbolsExtrudeSymbol3DLayerWrapper extends SymbolsExtrudeSymbol3DLayerGenerated {

    constructor(layer: symbolsExtrudeSymbol3DLayer) {
        super(layer);
    }

}

export async function buildJsSymbolsExtrudeSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSymbolsExtrudeSymbol3DLayerGenerated} = await import('./symbolsExtrudeSymbol3DLayer.gb');
    return await buildJsSymbolsExtrudeSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSymbolsExtrudeSymbol3DLayer(jsObject: any): Promise<any> {
    let {buildDotNetSymbolsExtrudeSymbol3DLayerGenerated} = await import('./symbolsExtrudeSymbol3DLayer.gb');
    return await buildDotNetSymbolsExtrudeSymbol3DLayerGenerated(jsObject);
}
