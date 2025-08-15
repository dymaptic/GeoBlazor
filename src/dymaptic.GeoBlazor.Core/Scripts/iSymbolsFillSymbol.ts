
export async function buildJsISymbolsFillSymbol(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsISymbolsFillSymbolGenerated } = await import('./iSymbolsFillSymbol.gb');
    return await buildJsISymbolsFillSymbolGenerated(dotNetObject, viewId);
}     

export async function buildDotNetISymbolsFillSymbol(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetISymbolsFillSymbolGenerated } = await import('./iSymbolsFillSymbol.gb');
    return await buildDotNetISymbolsFillSymbolGenerated(jsObject, viewId);
}
