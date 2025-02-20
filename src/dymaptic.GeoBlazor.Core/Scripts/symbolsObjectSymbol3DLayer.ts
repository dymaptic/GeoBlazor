import symbolsObjectSymbol3DLayer = __esri.symbolsObjectSymbol3DLayer;
import SymbolsObjectSymbol3DLayerGenerated from './symbolsObjectSymbol3DLayer.gb';

export default class SymbolsObjectSymbol3DLayerWrapper extends SymbolsObjectSymbol3DLayerGenerated {

    constructor(layer: symbolsObjectSymbol3DLayer) {
        super(layer);
    }

}

export async function buildJsSymbolsObjectSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSymbolsObjectSymbol3DLayerGenerated} = await import('./symbolsObjectSymbol3DLayer.gb');
    return await buildJsSymbolsObjectSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSymbolsObjectSymbol3DLayer(jsObject: any): Promise<any> {
    let {buildDotNetSymbolsObjectSymbol3DLayerGenerated} = await import('./symbolsObjectSymbol3DLayer.gb');
    return await buildDotNetSymbolsObjectSymbol3DLayerGenerated(jsObject);
}
