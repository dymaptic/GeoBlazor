export async function buildJsCIMLineSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMLineSymbolGenerated } = await import('./cIMLineSymbol.gb');
    return await buildJsCIMLineSymbolGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCIMLineSymbol(jsObject: any): Promise<any> {
    let { buildDotNetCIMLineSymbolGenerated } = await import('./cIMLineSymbol.gb');
    return await buildDotNetCIMLineSymbolGenerated(jsObject);
}
