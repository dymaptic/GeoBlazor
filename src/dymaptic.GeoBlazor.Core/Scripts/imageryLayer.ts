// override generated code in this file
import ImageryLayerGenerated from './imageryLayer.gb';
import ImageryLayer from '@arcgis/core/layers/ImageryLayer';

export default class ImageryLayerWrapper extends ImageryLayerGenerated {

    constructor(layer: ImageryLayer) {
        super(layer);
    }

}

export async function buildJsImageryLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageryLayerGenerated} = await import('./imageryLayer.gb');
    return await buildJsImageryLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageryLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetImageryLayerGenerated} = await import('./imageryLayer.gb');
    return await buildDotNetImageryLayerGenerated(jsObject, layerId, viewId);
}
