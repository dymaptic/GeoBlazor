
export async function buildJsLineSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLineSymbolGenerated } = await import('./lineSymbol.gb');
    return await buildJsLineSymbolGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLineSymbol(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLineSymbolGenerated } = await import('./lineSymbol.gb');
    return await buildDotNetLineSymbolGenerated(jsObject, layerId, viewId);
}
