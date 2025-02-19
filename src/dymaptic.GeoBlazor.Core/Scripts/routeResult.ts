export async function buildJsRouteResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRouteResultGenerated } = await import('./routeResult.gb');
    return await buildJsRouteResultGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetRouteResult(jsObject: any): Promise<any> {
    let { buildDotNetRouteResultGenerated } = await import('./routeResult.gb');
    return await buildDotNetRouteResultGenerated(jsObject);
}
