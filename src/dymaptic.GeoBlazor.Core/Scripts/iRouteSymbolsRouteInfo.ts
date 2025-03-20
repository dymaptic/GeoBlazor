
export async function buildJsIRouteSymbolsRouteInfo(dotNetObject: any): Promise<any> {
    let { buildJsIRouteSymbolsRouteInfoGenerated } = await import('./iRouteSymbolsRouteInfo.gb');
    return await buildJsIRouteSymbolsRouteInfoGenerated(dotNetObject);
}     

export async function buildDotNetIRouteSymbolsRouteInfo(jsObject: any): Promise<any> {
    let { buildDotNetIRouteSymbolsRouteInfoGenerated } = await import('./iRouteSymbolsRouteInfo.gb');
    return await buildDotNetIRouteSymbolsRouteInfoGenerated(jsObject);
}
