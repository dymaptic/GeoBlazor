
export async function buildJsISymbolsMarkerSymbol(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsISymbolsMarkerSymbolGenerated } = await import('./iSymbolsMarkerSymbol.gb');
    return await buildJsISymbolsMarkerSymbolGenerated(dotNetObject, viewId);
}     

export async function buildDotNetISymbolsMarkerSymbol(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetISymbolsMarkerSymbolGenerated } = await import('./iSymbolsMarkerSymbol.gb');
    return await buildDotNetISymbolsMarkerSymbolGenerated(jsObject, viewId);
}
