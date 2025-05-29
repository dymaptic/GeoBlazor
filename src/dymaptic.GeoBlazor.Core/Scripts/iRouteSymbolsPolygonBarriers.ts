
export async function buildJsIRouteSymbolsPolygonBarriers(dotNetObject: any): Promise<any> {
    let { buildJsIRouteSymbolsPolygonBarriersGenerated } = await import('./iRouteSymbolsPolygonBarriers.gb');
    return await buildJsIRouteSymbolsPolygonBarriersGenerated(dotNetObject);
}     

export async function buildDotNetIRouteSymbolsPolygonBarriers(jsObject: any): Promise<any> {
    let { buildDotNetIRouteSymbolsPolygonBarriersGenerated } = await import('./iRouteSymbolsPolygonBarriers.gb');
    return await buildDotNetIRouteSymbolsPolygonBarriersGenerated(jsObject);
}
