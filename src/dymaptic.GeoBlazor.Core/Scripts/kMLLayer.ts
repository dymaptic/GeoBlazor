// override generated code in this file
import KMLLayerGenerated from './kMLLayer.gb';
import KMLLayer from '@arcgis/core/layers/KMLLayer';
import {buildEncodedJson} from "./geoBlazorCore";

export default class KMLLayerWrapper extends KMLLayerGenerated {

    constructor(layer: KMLLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetKMLLayer(result, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }
}

export async function buildJsKMLLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsKMLLayerGenerated} = await import('./kMLLayer.gb');
    return await buildJsKMLLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetKMLLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetKMLLayerGenerated} = await import('./kMLLayer.gb');
    return await buildDotNetKMLLayerGenerated(jsObject, viewId);
}
