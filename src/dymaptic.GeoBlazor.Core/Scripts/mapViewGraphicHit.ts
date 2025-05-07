
export async function buildJsMapViewGraphicHit(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMapViewGraphicHitGenerated } = await import('./mapViewGraphicHit.gb');
    return await buildJsMapViewGraphicHitGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMapViewGraphicHit(jsObject: any): Promise<any> {
    let { buildDotNetMapViewGraphicHitGenerated } = await import('./mapViewGraphicHit.gb');
    return await buildDotNetMapViewGraphicHitGenerated(jsObject);
}
