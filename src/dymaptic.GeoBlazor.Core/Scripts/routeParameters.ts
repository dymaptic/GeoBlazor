export async function buildJsRouteParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRouteParametersGenerated} = await import('./routeParameters.gb');
    return await buildJsRouteParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRouteParameters(jsObject: any): Promise<any> {
    let {buildDotNetRouteParametersGenerated} = await import('./routeParameters.gb');
    return await buildDotNetRouteParametersGenerated(jsObject);
}
