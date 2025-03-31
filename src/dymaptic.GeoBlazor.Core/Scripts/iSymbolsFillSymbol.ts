
export async function buildJsISymbolsFillSymbol(dotNetObject: any): Promise<any> {
    let { buildJsISymbolsFillSymbolGenerated } = await import('./iSymbolsFillSymbol.gb');
    return await buildJsISymbolsFillSymbolGenerated(dotNetObject);
}     

export async function buildDotNetISymbolsFillSymbol(jsObject: any): Promise<any> {
    let { buildDotNetISymbolsFillSymbolGenerated } = await import('./iSymbolsFillSymbol.gb');
    return await buildDotNetISymbolsFillSymbolGenerated(jsObject);
}
