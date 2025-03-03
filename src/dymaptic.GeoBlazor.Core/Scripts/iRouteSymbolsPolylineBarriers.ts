
export async function buildJsIRouteSymbolsPolylineBarriers(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIRouteSymbolsPolylineBarriersGenerated } = await import('./iRouteSymbolsPolylineBarriers.gb');
    return await buildJsIRouteSymbolsPolylineBarriersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIRouteSymbolsPolylineBarriers(jsObject: any): Promise<any> {
    let { buildDotNetIRouteSymbolsPolylineBarriersGenerated } = await import('./iRouteSymbolsPolylineBarriers.gb');
    return await buildDotNetIRouteSymbolsPolylineBarriersGenerated(jsObject);
}
