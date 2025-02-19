// override generated code in this file
import IObjectSymbol3DLayerGenerated from './iObjectSymbol3DLayer.gb';
import ObjectSymbol3DLayer from '@arcgis/core/symbols/ObjectSymbol3DLayer';

export default class IObjectSymbol3DLayerWrapper extends IObjectSymbol3DLayerGenerated {

    constructor(layer: ObjectSymbol3DLayer) {
        super(layer);
    }
    
}

export async function buildJsIObjectSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIObjectSymbol3DLayerGenerated } = await import('./iObjectSymbol3DLayer.gb');
    return await buildJsIObjectSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIObjectSymbol3DLayer(jsObject: any): Promise<any> {
    let { buildDotNetIObjectSymbol3DLayerGenerated } = await import('./iObjectSymbol3DLayer.gb');
    return await buildDotNetIObjectSymbol3DLayerGenerated(jsObject);
}
