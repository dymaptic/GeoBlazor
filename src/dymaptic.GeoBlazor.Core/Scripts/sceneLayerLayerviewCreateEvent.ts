
export async function buildJsSceneLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneLayerLayerviewCreateEventGenerated } = await import('./sceneLayerLayerviewCreateEvent.gb');
    return await buildJsSceneLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneLayerLayerviewCreateEvent(jsObject: any): Promise<any> {
    let { buildDotNetSceneLayerLayerviewCreateEventGenerated } = await import('./sceneLayerLayerviewCreateEvent.gb');
    return await buildDotNetSceneLayerLayerviewCreateEventGenerated(jsObject);
}
