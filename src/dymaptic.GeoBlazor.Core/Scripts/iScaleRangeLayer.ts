import ScaleRangeLayer = __esri.ScaleRangeLayer;
import IScaleRangeLayerGenerated from './iScaleRangeLayer.gb';

export default class IScaleRangeLayerWrapper extends IScaleRangeLayerGenerated {

    constructor(layer: ScaleRangeLayer) {
        super(layer);
    }
    
}

export async function buildJsIScaleRangeLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIScaleRangeLayerGenerated } = await import('./iScaleRangeLayer.gb');
    return await buildJsIScaleRangeLayerGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetIScaleRangeLayer(jsObject: any): Promise<any> {
    let { buildDotNetIScaleRangeLayerGenerated } = await import('./iScaleRangeLayer.gb');
    return await buildDotNetIScaleRangeLayerGenerated(jsObject);
}
