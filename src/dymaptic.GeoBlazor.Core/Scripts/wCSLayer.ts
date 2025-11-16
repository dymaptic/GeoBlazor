// override generated code in this file
import WCSLayerGenerated from './wCSLayer.gb';
import WCSLayer from '@arcgis/core/layers/WCSLayer';
import {buildEncodedJson, hasValue} from "./arcGisJsInterop";

export default class WCSLayerWrapper extends WCSLayerGenerated {

    constructor(layer: WCSLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetWCSLayer(result, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }
}

export async function buildJsWCSLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWCSLayerGenerated} = await import('./wCSLayer.gb');
    let jsObject = await buildJsWCSLayerGenerated(dotNetObject, layerId, viewId);

    if (hasValue(dotNetObject.renderer)) {
        let {buildJsImageryRenderer} = await import('./imageryRenderer');
        jsObject.renderer = await buildJsImageryRenderer(dotNetObject.renderer, layerId, viewId);
    }
    
    return jsObject;
}

export async function buildDotNetWCSLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetWCSLayerGenerated} = await import('./wCSLayer.gb');
    let dnObject = await buildDotNetWCSLayerGenerated(jsObject, viewId);
    
    if (hasValue(jsObject.renderer)) {
        let {buildDotNetImageryRenderer} = await import('./imageryRenderer');
        dnObject.renderer = await buildDotNetImageryRenderer(jsObject.renderer, viewId);
    }
    
    return dnObject;
}
