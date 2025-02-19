
export async function buildJsCIMTextSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMTextSymbolGenerated } = await import('./cIMTextSymbol.gb');
    return await buildJsCIMTextSymbolGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMTextSymbol(jsObject: any): Promise<any> {
    let { buildDotNetCIMTextSymbolGenerated } = await import('./cIMTextSymbol.gb');
    return await buildDotNetCIMTextSymbolGenerated(jsObject);
}
