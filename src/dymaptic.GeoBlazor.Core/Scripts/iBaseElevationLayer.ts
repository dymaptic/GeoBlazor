import BaseElevationLayer from '@arcgis/core/layers/BaseElevationLayer';
import IBaseElevationLayerGenerated from './iBaseElevationLayer.gb';

export default class IBaseElevationLayerWrapper extends IBaseElevationLayerGenerated {

    constructor(layer: BaseElevationLayer) {
        super(layer);
    }
    
}

export async function buildJsIBaseElevationLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIBaseElevationLayerGenerated } = await import('./iBaseElevationLayer.gb');
    return await buildJsIBaseElevationLayerGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetIBaseElevationLayer(jsObject: any): Promise<any> {
    let { buildDotNetIBaseElevationLayerGenerated } = await import('./iBaseElevationLayer.gb');
    return await buildDotNetIBaseElevationLayerGenerated(jsObject);
}
