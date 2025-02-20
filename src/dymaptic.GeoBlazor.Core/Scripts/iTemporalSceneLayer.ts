// override generated code in this file
import ITemporalSceneLayerGenerated from './iTemporalSceneLayer.gb';
import TemporalSceneLayer = __esri.TemporalSceneLayer;

export default class ITemporalSceneLayerWrapper extends ITemporalSceneLayerGenerated {

    constructor(layer: TemporalSceneLayer) {
        super(layer);
    }

}

export async function buildJsITemporalSceneLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsITemporalSceneLayerGenerated} = await import('./iTemporalSceneLayer.gb');
    return await buildJsITemporalSceneLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetITemporalSceneLayer(jsObject: any): Promise<any> {
    let {buildDotNetITemporalSceneLayerGenerated} = await import('./iTemporalSceneLayer.gb');
    return await buildDotNetITemporalSceneLayerGenerated(jsObject);
}
