
export async function buildJsSceneViewHitTestOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneViewHitTestOptionsGenerated } = await import('./sceneViewHitTestOptions.gb');
    return await buildJsSceneViewHitTestOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneViewHitTestOptions(jsObject: any): Promise<any> {
    let { buildDotNetSceneViewHitTestOptionsGenerated } = await import('./sceneViewHitTestOptions.gb');
    return await buildDotNetSceneViewHitTestOptionsGenerated(jsObject);
}
