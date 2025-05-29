
export async function buildJsIRouteStopSymbolsUnlocated(dotNetObject: any): Promise<any> {
    let { buildJsIRouteStopSymbolsUnlocatedGenerated } = await import('./iRouteStopSymbolsUnlocated.gb');
    return await buildJsIRouteStopSymbolsUnlocatedGenerated(dotNetObject);
}     

export async function buildDotNetIRouteStopSymbolsUnlocated(jsObject: any): Promise<any> {
    let { buildDotNetIRouteStopSymbolsUnlocatedGenerated } = await import('./iRouteStopSymbolsUnlocated.gb');
    return await buildDotNetIRouteStopSymbolsUnlocatedGenerated(jsObject);
}
