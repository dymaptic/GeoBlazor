export async function buildJsRouteLayerSolveResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRouteLayerSolveResultGenerated} = await import('./routeLayerSolveResult.gb');
    return await buildJsRouteLayerSolveResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRouteLayerSolveResult(jsObject: any): Promise<any> {
    let {buildDotNetRouteLayerSolveResultGenerated} = await import('./routeLayerSolveResult.gb');
    return await buildDotNetRouteLayerSolveResultGenerated(jsObject);
}
