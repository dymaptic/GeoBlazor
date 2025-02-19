import symbolsLineSymbol3DLayer = __esri.symbolsLineSymbol3DLayer;
import SymbolsLineSymbol3DLayerGenerated from './symbolsLineSymbol3DLayer.gb';

export default class SymbolsLineSymbol3DLayerWrapper extends SymbolsLineSymbol3DLayerGenerated {

    constructor(layer: symbolsLineSymbol3DLayer) {
        super(layer);
    }
    
}

export async function buildJsSymbolsLineSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbolsLineSymbol3DLayerGenerated } = await import('./symbolsLineSymbol3DLayer.gb');
    return await buildJsSymbolsLineSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSymbolsLineSymbol3DLayer(jsObject: any): Promise<any> {
    let { buildDotNetSymbolsLineSymbol3DLayerGenerated } = await import('./symbolsLineSymbol3DLayer.gb');
    return await buildDotNetSymbolsLineSymbol3DLayerGenerated(jsObject);
}
