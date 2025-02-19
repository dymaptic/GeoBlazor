
export async function buildJsSceneLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneLayerLayerviewDestroyEventGenerated } = await import('./sceneLayerLayerviewDestroyEvent.gb');
    return await buildJsSceneLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneLayerLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let { buildDotNetSceneLayerLayerviewDestroyEventGenerated } = await import('./sceneLayerLayerviewDestroyEvent.gb');
    return await buildDotNetSceneLayerLayerviewDestroyEventGenerated(jsObject);
}
