import UnknownLayer from '@arcgis/core/layers/UnknownLayer';
import IUnknownLayerGenerated from './iUnknownLayer.gb';

export default class IUnknownLayerWrapper extends IUnknownLayerGenerated {

    constructor(layer: UnknownLayer) {
        super(layer);
    }

}

export async function buildJsIUnknownLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIUnknownLayerGenerated} = await import('./iUnknownLayer.gb');
    return await buildJsIUnknownLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIUnknownLayer(jsObject: any): Promise<any> {
    let {buildDotNetIUnknownLayerGenerated} = await import('./iUnknownLayer.gb');
    return await buildDotNetIUnknownLayerGenerated(jsObject);
}
