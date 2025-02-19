
export async function buildJsCIMPolygonSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMPolygonSymbolGenerated } = await import('./cIMPolygonSymbol.gb');
    return await buildJsCIMPolygonSymbolGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMPolygonSymbol(jsObject: any): Promise<any> {
    let { buildDotNetCIMPolygonSymbolGenerated } = await import('./cIMPolygonSymbol.gb');
    return await buildDotNetCIMPolygonSymbolGenerated(jsObject);
}
