export async function buildJsRouteSymbols(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRouteSymbolsGenerated} = await import('./routeSymbols.gb');
    return await buildJsRouteSymbolsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRouteSymbols(jsObject: any): Promise<any> {
    let {buildDotNetRouteSymbolsGenerated} = await import('./routeSymbols.gb');
    return await buildDotNetRouteSymbolsGenerated(jsObject);
}
