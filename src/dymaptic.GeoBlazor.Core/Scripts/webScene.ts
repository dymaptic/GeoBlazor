
export async function buildJsWebScene(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebSceneGenerated } = await import('./webScene.gb');
    return await buildJsWebSceneGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebScene(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetWebSceneGenerated } = await import('./webScene.gb');
    return await buildDotNetWebSceneGenerated(jsObject, layerId, viewId);
}
