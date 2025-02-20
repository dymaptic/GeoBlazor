// override generated code in this file


export async function buildJsRouteHit(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRouteHitGenerated} = await import('./routeHit.gb');
    return await buildJsRouteHitGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRouteHit(jsObject: any): Promise<any> {
    let {buildDotNetRouteHitGenerated} = await import('./routeHit.gb');
    return await buildDotNetRouteHitGenerated(jsObject);
}
