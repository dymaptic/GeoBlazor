
export async function buildJsMapViewMediaHit(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMapViewMediaHitGenerated } = await import('./mapViewMediaHit.gb');
    return await buildJsMapViewMediaHitGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMapViewMediaHit(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetMapViewMediaHitGenerated } = await import('./mapViewMediaHit.gb');
    return await buildDotNetMapViewMediaHitGenerated(jsObject, viewId);
}
