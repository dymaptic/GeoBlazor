// override generated code in this file
import KMLLayerGenerated from './kMLLayer.gb';
import KMLLayer from '@arcgis/core/layers/KMLLayer';
import {buildEncodedJson} from "./geoBlazorCore";

export default class KMLLayerWrapper extends KMLLayerGenerated {

    constructor(layer: KMLLayer) {
        super(layer);
    }

    async load(signal: AbortSignal): Promise<any> {
        let options = {signal: signal};
        let result = await this.layer.load(options);
        return await buildDotNetKMLLayer(result, this.layerId, this.viewId);
    }
}

export async function buildJsKMLLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsKMLLayerGenerated} = await import('./kMLLayer.gb');
    return await buildJsKMLLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetKMLLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetKMLLayerGenerated} = await import('./kMLLayer.gb');
    return await buildDotNetKMLLayerGenerated(jsObject, layerId, viewId);
}
