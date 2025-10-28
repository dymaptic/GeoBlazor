// override generated code in this file
import UnsupportedLayerGenerated from './unsupportedLayer.gb';
import UnsupportedLayer from '@arcgis/core/layers/UnsupportedLayer';
import {buildEncodedJson} from "./arcGisJsInterop";

export default class UnsupportedLayerWrapper extends UnsupportedLayerGenerated {

    constructor(layer: UnsupportedLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetUnsupportedLayer(result, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }
}

export async function buildJsUnsupportedLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUnsupportedLayerGenerated } = await import('./unsupportedLayer.gb');
    return await buildJsUnsupportedLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUnsupportedLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetUnsupportedLayerGenerated } = await import('./unsupportedLayer.gb');
    return await buildDotNetUnsupportedLayerGenerated(jsObject, viewId);
}
