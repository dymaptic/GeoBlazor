// override generated code in this file
import WebTileLayerGenerated from './webTileLayer.gb';
import WebTileLayer from '@arcgis/core/layers/WebTileLayer';
import {buildEncodedJson} from "./geoBlazorCore";

export default class WebTileLayerWrapper extends WebTileLayerGenerated {

    constructor(layer: WebTileLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetWebTileLayer(result, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }
}

export async function buildJsWebTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWebTileLayerGenerated} = await import('./webTileLayer.gb');
    return await buildJsWebTileLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWebTileLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetWebTileLayerGenerated} = await import('./webTileLayer.gb');
    return await buildDotNetWebTileLayerGenerated(jsObject, viewId);
}
