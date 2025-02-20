import symbolsPathSymbol3DLayer = __esri.symbolsPathSymbol3DLayer;
import SymbolsPathSymbol3DLayerGenerated from './symbolsPathSymbol3DLayer.gb';

export default class SymbolsPathSymbol3DLayerWrapper extends SymbolsPathSymbol3DLayerGenerated {

    constructor(layer: symbolsPathSymbol3DLayer) {
        super(layer);
    }

}

export async function buildJsSymbolsPathSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSymbolsPathSymbol3DLayerGenerated} = await import('./symbolsPathSymbol3DLayer.gb');
    return await buildJsSymbolsPathSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSymbolsPathSymbol3DLayer(jsObject: any): Promise<any> {
    let {buildDotNetSymbolsPathSymbol3DLayerGenerated} = await import('./symbolsPathSymbol3DLayer.gb');
    return await buildDotNetSymbolsPathSymbol3DLayerGenerated(jsObject);
}
