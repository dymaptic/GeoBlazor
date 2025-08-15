
export async function buildJsFillSymbol(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsFillSymbolGenerated } = await import('./fillSymbol.gb');
    return await buildJsFillSymbolGenerated(dotNetObject, viewId);
}     

export async function buildDotNetFillSymbol(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFillSymbolGenerated } = await import('./fillSymbol.gb');
    return await buildDotNetFillSymbolGenerated(jsObject, viewId);
}
