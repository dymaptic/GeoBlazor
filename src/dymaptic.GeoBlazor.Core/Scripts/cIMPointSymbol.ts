export async function buildJsCIMPointSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMPointSymbolGenerated } = await import('./cIMPointSymbol.gb');
    return await buildJsCIMPointSymbolGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCIMPointSymbol(jsObject: any): Promise<any> {
    let { buildDotNetCIMPointSymbolGenerated } = await import('./cIMPointSymbol.gb');
    return await buildDotNetCIMPointSymbolGenerated(jsObject);
}
