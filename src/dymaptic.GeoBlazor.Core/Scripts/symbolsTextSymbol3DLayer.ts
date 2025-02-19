import symbolsTextSymbol3DLayer = __esri.symbolsTextSymbol3DLayer;
import SymbolsTextSymbol3DLayerGenerated from './symbolsTextSymbol3DLayer.gb';

export default class SymbolsTextSymbol3DLayerWrapper extends SymbolsTextSymbol3DLayerGenerated {

    constructor(layer: symbolsTextSymbol3DLayer) {
        super(layer);
    }
    
}

export async function buildJsSymbolsTextSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbolsTextSymbol3DLayerGenerated } = await import('./symbolsTextSymbol3DLayer.gb');
    return await buildJsSymbolsTextSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSymbolsTextSymbol3DLayer(jsObject: any): Promise<any> {
    let { buildDotNetSymbolsTextSymbol3DLayerGenerated } = await import('./symbolsTextSymbol3DLayer.gb');
    return await buildDotNetSymbolsTextSymbol3DLayerGenerated(jsObject);
}
