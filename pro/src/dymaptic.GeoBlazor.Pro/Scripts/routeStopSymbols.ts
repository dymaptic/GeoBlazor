
export async function buildJsRouteStopSymbols(dotNetObject: any): Promise<any> {
    let { buildJsRouteStopSymbolsGenerated } = await import('./routeStopSymbols.gb');
    return await buildJsRouteStopSymbolsGenerated(dotNetObject);
}     

export async function buildDotNetRouteStopSymbols(jsObject: any): Promise<any> {
    let { buildDotNetRouteStopSymbolsGenerated } = await import('./routeStopSymbols.gb');
    return await buildDotNetRouteStopSymbolsGenerated(jsObject);
}
