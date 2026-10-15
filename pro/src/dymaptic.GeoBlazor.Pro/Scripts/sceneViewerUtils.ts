// override generated code in this file
import SceneViewerUtilsGenerated from './sceneViewerUtils.gb';
import sceneViewerUtils = __esri.sceneViewerUtils;

export default class SceneViewerUtilsWrapper extends SceneViewerUtilsGenerated {

    constructor(component: sceneViewerUtils) {
        super(component);
    }
    
}

export async function buildJsSceneViewerUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneViewerUtilsGenerated } = await import('./sceneViewerUtils.gb');
    return await buildJsSceneViewerUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneViewerUtils(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSceneViewerUtilsGenerated } = await import('./sceneViewerUtils.gb');
    return await buildDotNetSceneViewerUtilsGenerated(jsObject, layerId, viewId);
}
