// override generated code in this file
import ITextSymbol3DLayerGenerated from './iTextSymbol3DLayer.gb';
import TextSymbol3DLayer from '@arcgis/core/symbols/TextSymbol3DLayer';

export default class ITextSymbol3DLayerWrapper extends ITextSymbol3DLayerGenerated {

    constructor(layer: TextSymbol3DLayer) {
        super(layer);
    }

}

export async function buildJsITextSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsITextSymbol3DLayerGenerated} = await import('./iTextSymbol3DLayer.gb');
    return await buildJsITextSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetITextSymbol3DLayer(jsObject: any): Promise<any> {
    let {buildDotNetITextSymbol3DLayerGenerated} = await import('./iTextSymbol3DLayer.gb');
    return await buildDotNetITextSymbol3DLayerGenerated(jsObject);
}
