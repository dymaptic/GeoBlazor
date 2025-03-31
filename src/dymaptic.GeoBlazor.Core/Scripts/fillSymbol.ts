
export async function buildJsFillSymbol(dotNetObject: any): Promise<any> {
    let { buildJsFillSymbolGenerated } = await import('./fillSymbol.gb');
    return await buildJsFillSymbolGenerated(dotNetObject);
}     

export async function buildDotNetFillSymbol(jsObject: any): Promise<any> {
    let { buildDotNetFillSymbolGenerated } = await import('./fillSymbol.gb');
    return await buildDotNetFillSymbolGenerated(jsObject);
}
