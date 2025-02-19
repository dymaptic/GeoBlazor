import sceneViewerUtils = __esri.sceneViewerUtils;
import SceneViewerUtilsGenerated from './sceneViewerUtils.gb';

export default class SceneViewerUtilsWrapper extends SceneViewerUtilsGenerated {

    constructor(component: sceneViewerUtils) {
        super(component);
    }
    
}

export async function buildJsSceneViewerUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneViewerUtilsGenerated } = await import('./sceneViewerUtils.gb');
    return await buildJsSceneViewerUtilsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSceneViewerUtils(jsObject: any): Promise<any> {
    let { buildDotNetSceneViewerUtilsGenerated } = await import('./sceneViewerUtils.gb');
    return await buildDotNetSceneViewerUtilsGenerated(jsObject);
}
