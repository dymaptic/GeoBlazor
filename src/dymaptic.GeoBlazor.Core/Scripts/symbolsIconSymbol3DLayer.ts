import symbolsIconSymbol3DLayer = __esri.symbolsIconSymbol3DLayer;
import SymbolsIconSymbol3DLayerGenerated from './symbolsIconSymbol3DLayer.gb';

export default class SymbolsIconSymbol3DLayerWrapper extends SymbolsIconSymbol3DLayerGenerated {

    constructor(layer: symbolsIconSymbol3DLayer) {
        super(layer);
    }

}

export async function buildJsSymbolsIconSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSymbolsIconSymbol3DLayerGenerated} = await import('./symbolsIconSymbol3DLayer.gb');
    return await buildJsSymbolsIconSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSymbolsIconSymbol3DLayer(jsObject: any): Promise<any> {
    let {buildDotNetSymbolsIconSymbol3DLayerGenerated} = await import('./symbolsIconSymbol3DLayer.gb');
    return await buildDotNetSymbolsIconSymbol3DLayerGenerated(jsObject);
}
