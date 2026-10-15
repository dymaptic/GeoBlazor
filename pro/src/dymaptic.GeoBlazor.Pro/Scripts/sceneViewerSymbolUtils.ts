// override generated code in this file
import SceneViewerSymbolUtilsGenerated from './sceneViewerSymbolUtils.gb';
import SceneViewerSymbolUtils = __esri.SceneViewerSymbolUtils;

export default class SceneViewerSymbolUtilsWrapper extends SceneViewerSymbolUtilsGenerated {

    constructor(component: SceneViewerSymbolUtils) {
        super(component);
    }
    
}

export async function buildJsSceneViewerSymbolUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneViewerSymbolUtilsGenerated } = await import('./sceneViewerSymbolUtils.gb');
    return await buildJsSceneViewerSymbolUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneViewerSymbolUtils(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSceneViewerSymbolUtilsGenerated } = await import('./sceneViewerSymbolUtils.gb');
    return await buildDotNetSceneViewerSymbolUtilsGenerated(jsObject, layerId, viewId);
}
