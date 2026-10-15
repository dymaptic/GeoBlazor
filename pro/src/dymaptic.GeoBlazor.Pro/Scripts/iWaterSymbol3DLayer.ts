// override generated code in this file
import IWaterSymbol3DLayerGenerated from './iWaterSymbol3DLayer.gb';
import WaterSymbol3DLayer from '@arcgis/core/symbols/WaterSymbol3DLayer';

export default class IWaterSymbol3DLayerWrapper extends IWaterSymbol3DLayerGenerated {

    constructor(layer: WaterSymbol3DLayer) {
        super(layer);
    }

}

export async function buildJsIWaterSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIWaterSymbol3DLayerGenerated} = await import('./iWaterSymbol3DLayer.gb');
    return await buildJsIWaterSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIWaterSymbol3DLayer(jsObject: any): Promise<any> {
    let {buildDotNetIWaterSymbol3DLayerGenerated} = await import('./iWaterSymbol3DLayer.gb');
    return await buildDotNetIWaterSymbol3DLayerGenerated(jsObject);
}
