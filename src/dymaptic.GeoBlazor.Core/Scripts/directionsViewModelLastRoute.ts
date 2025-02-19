
export async function buildJsDirectionsViewModelLastRoute(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectionsViewModelLastRouteGenerated } = await import('./directionsViewModelLastRoute.gb');
    return await buildJsDirectionsViewModelLastRouteGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectionsViewModelLastRoute(jsObject: any): Promise<any> {
    let { buildDotNetDirectionsViewModelLastRouteGenerated } = await import('./directionsViewModelLastRoute.gb');
    return await buildDotNetDirectionsViewModelLastRouteGenerated(jsObject);
}
