// override generated code in this file
import ISymbolsSymbol3DLayerGenerated from './iSymbolsSymbol3DLayer.gb';
import symbolsSymbol3DLayer = __esri.symbolsSymbol3DLayer;

export default class ISymbolsSymbol3DLayerWrapper extends ISymbolsSymbol3DLayerGenerated {

    constructor(layer: symbolsSymbol3DLayer) {
        super(layer);
    }

}

export async function buildJsISymbolsSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsISymbolsSymbol3DLayerGenerated} = await import('./iSymbolsSymbol3DLayer.gb');
    return await buildJsISymbolsSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetISymbolsSymbol3DLayer(jsObject: any): Promise<any> {
    let {buildDotNetISymbolsSymbol3DLayerGenerated} = await import('./iSymbolsSymbol3DLayer.gb');
    return await buildDotNetISymbolsSymbol3DLayerGenerated(jsObject);
}
