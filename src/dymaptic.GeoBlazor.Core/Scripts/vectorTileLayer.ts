// override generated code in this file
import VectorTileLayerGenerated from './vectorTileLayer.gb';
import VectorTileLayer from '@arcgis/core/layers/VectorTileLayer';
import {buildEncodedJson} from "./geoBlazorCore";

export default class VectorTileLayerWrapper extends VectorTileLayerGenerated {

    constructor(layer: VectorTileLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetVectorTileLayer(result, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }
}

export async function buildJsVectorTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsVectorTileLayerGenerated} = await import('./vectorTileLayer.gb');
    return await buildJsVectorTileLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetVectorTileLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetVectorTileLayerGenerated} = await import('./vectorTileLayer.gb');
    return await buildDotNetVectorTileLayerGenerated(jsObject, viewId);
}
