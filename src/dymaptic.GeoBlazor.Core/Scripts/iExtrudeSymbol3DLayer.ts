import ExtrudeSymbol3DLayer from '@arcgis/core/symbols/ExtrudeSymbol3DLayer';
import IExtrudeSymbol3DLayerGenerated from './iExtrudeSymbol3DLayer.gb';

export default class IExtrudeSymbol3DLayerWrapper extends IExtrudeSymbol3DLayerGenerated {

    constructor(layer: ExtrudeSymbol3DLayer) {
        super(layer);
    }
    
}

export async function buildJsIExtrudeSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIExtrudeSymbol3DLayerGenerated } = await import('./iExtrudeSymbol3DLayer.gb');
    return await buildJsIExtrudeSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetIExtrudeSymbol3DLayer(jsObject: any): Promise<any> {
    let { buildDotNetIExtrudeSymbol3DLayerGenerated } = await import('./iExtrudeSymbol3DLayer.gb');
    return await buildDotNetIExtrudeSymbol3DLayerGenerated(jsObject);
}
