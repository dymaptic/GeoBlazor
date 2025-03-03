
export async function buildJsIRouteSymbolsDirectionLines(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIRouteSymbolsDirectionLinesGenerated } = await import('./iRouteSymbolsDirectionLines.gb');
    return await buildJsIRouteSymbolsDirectionLinesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIRouteSymbolsDirectionLines(jsObject: any): Promise<any> {
    let { buildDotNetIRouteSymbolsDirectionLinesGenerated } = await import('./iRouteSymbolsDirectionLines.gb');
    return await buildDotNetIRouteSymbolsDirectionLinesGenerated(jsObject);
}
