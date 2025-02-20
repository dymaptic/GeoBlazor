export async function buildJsRouteLayerUpdateRouteLayerSolveResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRouteLayerUpdateRouteLayerSolveResultGenerated} = await import('./routeLayerUpdateRouteLayerSolveResult.gb');
    return await buildJsRouteLayerUpdateRouteLayerSolveResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRouteLayerUpdateRouteLayerSolveResult(jsObject: any): Promise<any> {
    let {buildDotNetRouteLayerUpdateRouteLayerSolveResultGenerated} = await import('./routeLayerUpdateRouteLayerSolveResult.gb');
    return await buildDotNetRouteLayerUpdateRouteLayerSolveResultGenerated(jsObject);
}
