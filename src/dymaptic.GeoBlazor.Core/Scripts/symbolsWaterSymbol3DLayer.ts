import symbolsWaterSymbol3DLayer = __esri.symbolsWaterSymbol3DLayer;
import SymbolsWaterSymbol3DLayerGenerated from './symbolsWaterSymbol3DLayer.gb';

export default class SymbolsWaterSymbol3DLayerWrapper extends SymbolsWaterSymbol3DLayerGenerated {

    constructor(layer: symbolsWaterSymbol3DLayer) {
        super(layer);
    }
    
}

export async function buildJsSymbolsWaterSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbolsWaterSymbol3DLayerGenerated } = await import('./symbolsWaterSymbol3DLayer.gb');
    return await buildJsSymbolsWaterSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSymbolsWaterSymbol3DLayer(jsObject: any): Promise<any> {
    let { buildDotNetSymbolsWaterSymbol3DLayerGenerated } = await import('./symbolsWaterSymbol3DLayer.gb');
    return await buildDotNetSymbolsWaterSymbol3DLayerGenerated(jsObject);
}
