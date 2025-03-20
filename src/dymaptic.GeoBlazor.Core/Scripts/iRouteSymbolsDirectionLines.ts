
export async function buildJsIRouteSymbolsDirectionLines(dotNetObject: any): Promise<any> {
    let { buildJsIRouteSymbolsDirectionLinesGenerated } = await import('./iRouteSymbolsDirectionLines.gb');
    return await buildJsIRouteSymbolsDirectionLinesGenerated(dotNetObject);
}     

export async function buildDotNetIRouteSymbolsDirectionLines(jsObject: any): Promise<any> {
    let { buildDotNetIRouteSymbolsDirectionLinesGenerated } = await import('./iRouteSymbolsDirectionLines.gb');
    return await buildDotNetIRouteSymbolsDirectionLinesGenerated(jsObject);
}
