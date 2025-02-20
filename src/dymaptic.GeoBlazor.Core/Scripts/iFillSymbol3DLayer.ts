// override generated code in this file
import IFillSymbol3DLayerGenerated from './iFillSymbol3DLayer.gb';
import FillSymbol3DLayer from '@arcgis/core/symbols/FillSymbol3DLayer';

export default class IFillSymbol3DLayerWrapper extends IFillSymbol3DLayerGenerated {

    constructor(layer: FillSymbol3DLayer) {
        super(layer);
    }

}

export async function buildJsIFillSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIFillSymbol3DLayerGenerated} = await import('./iFillSymbol3DLayer.gb');
    return await buildJsIFillSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIFillSymbol3DLayer(jsObject: any): Promise<any> {
    let {buildDotNetIFillSymbol3DLayerGenerated} = await import('./iFillSymbol3DLayer.gb');
    return await buildDotNetIFillSymbol3DLayerGenerated(jsObject);
}
