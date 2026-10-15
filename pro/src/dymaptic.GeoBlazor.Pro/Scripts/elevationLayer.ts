// override generated code in this file
import ElevationLayerGenerated from './elevationLayer.gb';
import ElevationLayer from '@arcgis/core/layers/ElevationLayer';
import {buildEncodedJson} from "./geoBlazorCore";

export default class ElevationLayerWrapper extends ElevationLayerGenerated {

    constructor(layer: ElevationLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetElevationLayer(result, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }
}

export async function buildJsElevationLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsElevationLayerGenerated } = await import('./elevationLayer.gb');
    return await buildJsElevationLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetElevationLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetElevationLayerGenerated } = await import('./elevationLayer.gb');
    return await buildDotNetElevationLayerGenerated(jsObject, layerId, viewId);
}
