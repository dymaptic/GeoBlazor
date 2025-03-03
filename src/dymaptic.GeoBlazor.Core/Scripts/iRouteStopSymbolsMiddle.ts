
export async function buildJsIRouteStopSymbolsMiddle(dotNetObject: any): Promise<any> {
    let { buildJsIRouteStopSymbolsMiddleGenerated } = await import('./iRouteStopSymbolsMiddle.gb');
    return await buildJsIRouteStopSymbolsMiddleGenerated(dotNetObject);
}     

export async function buildDotNetIRouteStopSymbolsMiddle(jsObject: any): Promise<any> {
    let { buildDotNetIRouteStopSymbolsMiddleGenerated } = await import('./iRouteStopSymbolsMiddle.gb');
    return await buildDotNetIRouteStopSymbolsMiddleGenerated(jsObject);
}
