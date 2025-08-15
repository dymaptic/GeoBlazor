
export async function buildJsSceneViewToMapOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneViewToMapOptionsGenerated } = await import('./sceneViewToMapOptions.gb');
    return await buildJsSceneViewToMapOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneViewToMapOptions(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSceneViewToMapOptionsGenerated } = await import('./sceneViewToMapOptions.gb');
    return await buildDotNetSceneViewToMapOptionsGenerated(jsObject, viewId);
}
