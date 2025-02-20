// override generated code in this file
import SceneViewerColorUtilsGenerated from './sceneViewerColorUtils.gb';
import SceneViewerColorUtils = __esri.SceneViewerColorUtils;

export default class SceneViewerColorUtilsWrapper extends SceneViewerColorUtilsGenerated {

    constructor(component: SceneViewerColorUtils) {
        super(component);
    }

}

export async function buildJsSceneViewerColorUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSceneViewerColorUtilsGenerated} = await import('./sceneViewerColorUtils.gb');
    return await buildJsSceneViewerColorUtilsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSceneViewerColorUtils(jsObject: any): Promise<any> {
    let {buildDotNetSceneViewerColorUtilsGenerated} = await import('./sceneViewerColorUtils.gb');
    return await buildDotNetSceneViewerColorUtilsGenerated(jsObject);
}
