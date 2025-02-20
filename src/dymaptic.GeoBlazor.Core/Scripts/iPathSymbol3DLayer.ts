// override generated code in this file
import IPathSymbol3DLayerGenerated from './iPathSymbol3DLayer.gb';
import PathSymbol3DLayer from '@arcgis/core/symbols/PathSymbol3DLayer';

export default class IPathSymbol3DLayerWrapper extends IPathSymbol3DLayerGenerated {

    constructor(layer: PathSymbol3DLayer) {
        super(layer);
    }

}

export async function buildJsIPathSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIPathSymbol3DLayerGenerated} = await import('./iPathSymbol3DLayer.gb');
    return await buildJsIPathSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIPathSymbol3DLayer(jsObject: any): Promise<any> {
    let {buildDotNetIPathSymbol3DLayerGenerated} = await import('./iPathSymbol3DLayer.gb');
    return await buildDotNetIPathSymbol3DLayerGenerated(jsObject);
}
