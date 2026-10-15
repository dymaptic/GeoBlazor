
export async function buildJsRouteSymbols(dotNetObject: any): Promise<any> {
    let { buildJsRouteSymbolsGenerated } = await import('./routeSymbols.gb');
    return await buildJsRouteSymbolsGenerated(dotNetObject);
}     

export async function buildDotNetRouteSymbols(jsObject: any): Promise<any> {
    let { buildDotNetRouteSymbolsGenerated } = await import('./routeSymbols.gb');
    return await buildDotNetRouteSymbolsGenerated(jsObject);
}
