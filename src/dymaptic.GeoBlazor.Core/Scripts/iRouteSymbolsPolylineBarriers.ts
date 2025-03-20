
export async function buildJsIRouteSymbolsPolylineBarriers(dotNetObject: any): Promise<any> {
    let { buildJsIRouteSymbolsPolylineBarriersGenerated } = await import('./iRouteSymbolsPolylineBarriers.gb');
    return await buildJsIRouteSymbolsPolylineBarriersGenerated(dotNetObject);
}     

export async function buildDotNetIRouteSymbolsPolylineBarriers(jsObject: any): Promise<any> {
    let { buildDotNetIRouteSymbolsPolylineBarriersGenerated } = await import('./iRouteSymbolsPolylineBarriers.gb');
    return await buildDotNetIRouteSymbolsPolylineBarriersGenerated(jsObject);
}
