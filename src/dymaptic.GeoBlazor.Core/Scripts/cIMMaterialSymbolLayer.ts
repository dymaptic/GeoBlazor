// override generated code in this file
import CIMMaterialSymbolLayerGenerated from './cIMMaterialSymbolLayer.gb';
import CIMMaterialSymbolLayer = __esri.CIMMaterialSymbolLayer;

export default class CIMMaterialSymbolLayerWrapper extends CIMMaterialSymbolLayerGenerated {

    constructor(layer: CIMMaterialSymbolLayer) {
        super(layer);
    }

}

export async function buildJsCIMMaterialSymbolLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCIMMaterialSymbolLayerGenerated} = await import('./cIMMaterialSymbolLayer.gb');
    return await buildJsCIMMaterialSymbolLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCIMMaterialSymbolLayer(jsObject: any): Promise<any> {
    let {buildDotNetCIMMaterialSymbolLayerGenerated} = await import('./cIMMaterialSymbolLayer.gb');
    return await buildDotNetCIMMaterialSymbolLayerGenerated(jsObject);
}
