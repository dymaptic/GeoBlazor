// override generated code in this file
import ImageryLayerGenerated from './imageryLayer.gb';
import ImageryLayer from '@arcgis/core/layers/ImageryLayer';
import {hasValue} from "./arcGisJsInterop";

export default class ImageryLayerWrapper extends ImageryLayerGenerated {

    constructor(layer: ImageryLayer) {
        super(layer);
    }

}

export async function buildJsImageryLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageryLayerGenerated} = await import('./imageryLayer.gb');
    let jsObject = await buildJsImageryLayerGenerated(dotNetObject, layerId, viewId);
    
    if (hasValue(dotNetObject.renderer)) {
        let {buildJsImageryRenderer} = await import('./imageryRenderer');
        jsObject.renderer = await buildJsImageryRenderer(dotNetObject.renderer, layerId, viewId);
    }
    
    return jsObject;
}

export async function buildDotNetImageryLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetImageryLayerGenerated} = await import('./imageryLayer.gb');
    let dnObject = await buildDotNetImageryLayerGenerated(jsObject, viewId);
    
    if (hasValue(jsObject.renderer)) {
        let {buildDotNetImageryRenderer} = await import('./imageryRenderer');
        dnObject.renderer = await buildDotNetImageryRenderer(jsObject.renderer);
    }
    
    return dnObject;
}
