// override generated code in this file
import WebTileLayerGenerated from './webTileLayer.gb';
import WebTileLayer from '@arcgis/core/layers/WebTileLayer';
import {buildEncodedJson} from "./geoBlazorCore";

export default class WebTileLayerWrapper extends WebTileLayerGenerated {

    constructor(layer: WebTileLayer) {
        super(layer);
    }

    async load(signal: AbortSignal): Promise<any> {
        let options = {signal: signal};
        let result = await this.layer.load(options);
        return await buildDotNetWebTileLayer(result, this.layerId, this.viewId);
    }
}

export async function buildJsWebTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWebTileLayerGenerated} = await import('./webTileLayer.gb');
    return await buildJsWebTileLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWebTileLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetWebTileLayerGenerated} = await import('./webTileLayer.gb');
    return await buildDotNetWebTileLayerGenerated(jsObject, layerId, viewId);
}
