import SceneLayer from '@arcgis/core/layers/SceneLayer';
// override generated code in this file
import SceneLayerGenerated from './sceneLayer.gb';
import {buildEncodedJson} from "./geoBlazorCore";

export default class SceneLayerWrapper extends SceneLayerGenerated {

    constructor(layer: SceneLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetSceneLayer(result, this.layerId, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }
    
    async setSpatialReference(spatialReference: any): Promise<void> {
        let {buildJsSpatialReference} = await import('./spatialReference');
        this.layer.spatialReference = buildJsSpatialReference(spatialReference) as any;
    }
    
}

export async function buildJsSceneLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneLayerGenerated } = await import('./sceneLayer.gb');
    return await buildJsSceneLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSceneLayerGenerated } = await import('./sceneLayer.gb');
    return await buildDotNetSceneLayerGenerated(jsObject, layerId, viewId);
}
