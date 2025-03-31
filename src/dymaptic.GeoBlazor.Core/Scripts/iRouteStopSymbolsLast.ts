
export async function buildJsIRouteStopSymbolsLast(dotNetObject: any): Promise<any> {
    let { buildJsIRouteStopSymbolsLastGenerated } = await import('./iRouteStopSymbolsLast.gb');
    return await buildJsIRouteStopSymbolsLastGenerated(dotNetObject);
}     

export async function buildDotNetIRouteStopSymbolsLast(jsObject: any): Promise<any> {
    let { buildDotNetIRouteStopSymbolsLastGenerated } = await import('./iRouteStopSymbolsLast.gb');
    return await buildDotNetIRouteStopSymbolsLastGenerated(jsObject);
}
