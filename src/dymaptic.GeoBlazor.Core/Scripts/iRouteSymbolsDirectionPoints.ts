
export async function buildJsIRouteSymbolsDirectionPoints(dotNetObject: any): Promise<any> {
    let { buildJsIRouteSymbolsDirectionPointsGenerated } = await import('./iRouteSymbolsDirectionPoints.gb');
    return await buildJsIRouteSymbolsDirectionPointsGenerated(dotNetObject);
}     

export async function buildDotNetIRouteSymbolsDirectionPoints(jsObject: any): Promise<any> {
    let { buildDotNetIRouteSymbolsDirectionPointsGenerated } = await import('./iRouteSymbolsDirectionPoints.gb');
    return await buildDotNetIRouteSymbolsDirectionPointsGenerated(jsObject);
}
