export async function buildJsSceneViewGraphicHit(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSceneViewGraphicHitGenerated} = await import('./sceneViewGraphicHit.gb');
    return await buildJsSceneViewGraphicHitGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSceneViewGraphicHit(jsObject: any): Promise<any> {
    let {buildDotNetSceneViewGraphicHitGenerated} = await import('./sceneViewGraphicHit.gb');
    return await buildDotNetSceneViewGraphicHitGenerated(jsObject);
}
