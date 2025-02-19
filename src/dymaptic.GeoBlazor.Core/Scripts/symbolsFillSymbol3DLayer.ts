// override generated code in this file
import SymbolsFillSymbol3DLayerGenerated from './symbolsFillSymbol3DLayer.gb';
import symbolsFillSymbol3DLayer = __esri.symbolsFillSymbol3DLayer;

export default class SymbolsFillSymbol3DLayerWrapper extends SymbolsFillSymbol3DLayerGenerated {

    constructor(layer: symbolsFillSymbol3DLayer) {
        super(layer);
    }
    
}

export async function buildJsSymbolsFillSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbolsFillSymbol3DLayerGenerated } = await import('./symbolsFillSymbol3DLayer.gb');
    return await buildJsSymbolsFillSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSymbolsFillSymbol3DLayer(jsObject: any): Promise<any> {
    let { buildDotNetSymbolsFillSymbol3DLayerGenerated } = await import('./symbolsFillSymbol3DLayer.gb');
    return await buildDotNetSymbolsFillSymbol3DLayerGenerated(jsObject);
}
