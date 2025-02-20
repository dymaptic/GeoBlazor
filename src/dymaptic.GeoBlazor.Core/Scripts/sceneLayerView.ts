// override generated code in this file
import SceneLayerViewGenerated from './sceneLayerView.gb';
import SceneLayerView from '@arcgis/core/views/layers/SceneLayerView';

export default class SceneLayerViewWrapper extends SceneLayerViewGenerated {

    constructor(component: SceneLayerView) {
        super(component);
    }

}

export async function buildJsSceneLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSceneLayerViewGenerated} = await import('./sceneLayerView.gb');
    return await buildJsSceneLayerViewGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSceneLayerView(jsObject: any): Promise<any> {
    let {buildDotNetSceneLayerViewGenerated} = await import('./sceneLayerView.gb');
    return await buildDotNetSceneLayerViewGenerated(jsObject);
}
