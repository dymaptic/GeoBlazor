export async function buildJsSceneViewHitTestResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSceneViewHitTestResultGenerated} = await import('./sceneViewHitTestResult.gb');
    return await buildJsSceneViewHitTestResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSceneViewHitTestResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSceneViewHitTestResultGenerated} = await import('./sceneViewHitTestResult.gb');
    return await buildDotNetSceneViewHitTestResultGenerated(jsObject, layerId, viewId);
}
