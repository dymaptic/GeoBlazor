
export async function buildJsISymbolsMarkerSymbol(dotNetObject: any): Promise<any> {
    let { buildJsISymbolsMarkerSymbolGenerated } = await import('./iSymbolsMarkerSymbol.gb');
    return await buildJsISymbolsMarkerSymbolGenerated(dotNetObject);
}     

export async function buildDotNetISymbolsMarkerSymbol(jsObject: any): Promise<any> {
    let { buildDotNetISymbolsMarkerSymbolGenerated } = await import('./iSymbolsMarkerSymbol.gb');
    return await buildDotNetISymbolsMarkerSymbolGenerated(jsObject);
}
