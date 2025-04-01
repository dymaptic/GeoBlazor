
export async function buildJsIRouteStopSymbolsBreak(dotNetObject: any): Promise<any> {
    let { buildJsIRouteStopSymbolsBreakGenerated } = await import('./iRouteStopSymbolsBreak.gb');
    return await buildJsIRouteStopSymbolsBreakGenerated(dotNetObject);
}     

export async function buildDotNetIRouteStopSymbolsBreak(jsObject: any): Promise<any> {
    let { buildDotNetIRouteStopSymbolsBreakGenerated } = await import('./iRouteStopSymbolsBreak.gb');
    return await buildDotNetIRouteStopSymbolsBreakGenerated(jsObject);
}
