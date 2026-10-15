// override generated code in this file
import OGCFeatureLayerGenerated from './oGCFeatureLayer.gb';
import OGCFeatureLayer from '@arcgis/core/layers/OGCFeatureLayer';
import {buildEncodedJson} from "./geoBlazorCore";

export default class OGCFeatureLayerWrapper extends OGCFeatureLayerGenerated {

    constructor(layer: OGCFeatureLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetOGCFeatureLayer(result, this.layerId, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }
}

export async function buildJsOGCFeatureLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOGCFeatureLayerGenerated } = await import('./oGCFeatureLayer.gb');
    return await buildJsOGCFeatureLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOGCFeatureLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetOGCFeatureLayerGenerated } = await import('./oGCFeatureLayer.gb');
    return await buildDotNetOGCFeatureLayerGenerated(jsObject, layerId, viewId);
}
