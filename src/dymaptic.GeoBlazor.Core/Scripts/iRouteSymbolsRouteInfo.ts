
export async function buildJsIRouteSymbolsRouteInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIRouteSymbolsRouteInfoGenerated } = await import('./iRouteSymbolsRouteInfo.gb');
    return await buildJsIRouteSymbolsRouteInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIRouteSymbolsRouteInfo(jsObject: any): Promise<any> {
    let { buildDotNetIRouteSymbolsRouteInfoGenerated } = await import('./iRouteSymbolsRouteInfo.gb');
    return await buildDotNetIRouteSymbolsRouteInfoGenerated(jsObject);
}
