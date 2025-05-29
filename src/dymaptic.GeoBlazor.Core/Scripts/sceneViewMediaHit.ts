export async function buildJsSceneViewMediaHit(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSceneViewMediaHitGenerated} = await import('./sceneViewMediaHit.gb');
    return await buildJsSceneViewMediaHitGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSceneViewMediaHit(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSceneViewMediaHitGenerated} = await import('./sceneViewMediaHit.gb');
    return await buildDotNetSceneViewMediaHitGenerated(jsObject, layerId, viewId);
}
