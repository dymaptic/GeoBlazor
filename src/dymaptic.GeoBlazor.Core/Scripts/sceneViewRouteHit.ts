export async function buildJsSceneViewRouteHit(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneViewRouteHitGenerated } = await import('./sceneViewRouteHit.gb');
    return await buildJsSceneViewRouteHitGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSceneViewRouteHit(jsObject: any): Promise<any> {
    let { buildDotNetSceneViewRouteHitGenerated } = await import('./sceneViewRouteHit.gb');
    return await buildDotNetSceneViewRouteHitGenerated(jsObject);
}
