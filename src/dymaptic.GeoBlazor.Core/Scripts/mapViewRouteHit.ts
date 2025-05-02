
export async function buildJsMapViewRouteHit(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMapViewRouteHitGenerated } = await import('./mapViewRouteHit.gb');
    return await buildJsMapViewRouteHitGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMapViewRouteHit(jsObject: any): Promise<any> {
    let { buildDotNetMapViewRouteHitGenerated } = await import('./mapViewRouteHit.gb');
    return await buildDotNetMapViewRouteHitGenerated(jsObject);
}
