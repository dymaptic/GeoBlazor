
export async function buildJsIRouteStopSymbolsFirst(dotNetObject: any): Promise<any> {
    let { buildJsIRouteStopSymbolsFirstGenerated } = await import('./iRouteStopSymbolsFirst.gb');
    return await buildJsIRouteStopSymbolsFirstGenerated(dotNetObject);
}     

export async function buildDotNetIRouteStopSymbolsFirst(jsObject: any): Promise<any> {
    let { buildDotNetIRouteStopSymbolsFirstGenerated } = await import('./iRouteStopSymbolsFirst.gb');
    return await buildDotNetIRouteStopSymbolsFirstGenerated(jsObject);
}
