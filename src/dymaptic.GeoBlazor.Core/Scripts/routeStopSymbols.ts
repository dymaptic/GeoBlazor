
export async function buildJsRouteStopSymbols(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRouteStopSymbolsGenerated } = await import('./routeStopSymbols.gb');
    return await buildJsRouteStopSymbolsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRouteStopSymbols(jsObject: any): Promise<any> {
    let { buildDotNetRouteStopSymbolsGenerated } = await import('./routeStopSymbols.gb');
    return await buildDotNetRouteStopSymbolsGenerated(jsObject);
}
