// override generated code in this file
import UnknownLayerGenerated from './unknownLayer.gb';
import UnknownLayer from '@arcgis/core/layers/UnknownLayer';
import {buildEncodedJson} from "./geoBlazorCore";

export default class UnknownLayerWrapper extends UnknownLayerGenerated {

    constructor(layer: UnknownLayer) {
        super(layer);
    }

    async load(signal: AbortSignal): Promise<any> {
        let options = {signal: signal};
        let result = await this.layer.load(options);
        return await buildDotNetUnknownLayer(result, this.layerId, this.viewId);
    }
}

export async function buildJsUnknownLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUnknownLayerGenerated } = await import('./unknownLayer.gb');
    return await buildJsUnknownLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUnknownLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetUnknownLayerGenerated } = await import('./unknownLayer.gb');
    return await buildDotNetUnknownLayerGenerated(jsObject, layerId, viewId);
}
