
export async function buildJsDirectionsLastRoute(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectionsLastRouteGenerated } = await import('./directionsLastRoute.gb');
    return await buildJsDirectionsLastRouteGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectionsLastRoute(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDirectionsLastRouteGenerated } = await import('./directionsLastRoute.gb');
    return await buildDotNetDirectionsLastRouteGenerated(jsObject, layerId, viewId);
}
