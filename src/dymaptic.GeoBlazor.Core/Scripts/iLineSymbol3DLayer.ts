// override generated code in this file
import ILineSymbol3DLayerGenerated from './iLineSymbol3DLayer.gb';
import LineSymbol3DLayer from '@arcgis/core/symbols/LineSymbol3DLayer';

export default class ILineSymbol3DLayerWrapper extends ILineSymbol3DLayerGenerated {

    constructor(layer: LineSymbol3DLayer) {
        super(layer);
    }

}

export async function buildJsILineSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsILineSymbol3DLayerGenerated} = await import('./iLineSymbol3DLayer.gb');
    return await buildJsILineSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetILineSymbol3DLayer(jsObject: any): Promise<any> {
    let {buildDotNetILineSymbol3DLayerGenerated} = await import('./iLineSymbol3DLayer.gb');
    return await buildDotNetILineSymbol3DLayerGenerated(jsObject);
}
