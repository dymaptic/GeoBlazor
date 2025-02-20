export async function buildJsCIMMultiLayerSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCIMMultiLayerSymbolGenerated} = await import('./cIMMultiLayerSymbol.gb');
    return await buildJsCIMMultiLayerSymbolGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCIMMultiLayerSymbol(jsObject: any): Promise<any> {
    let {buildDotNetCIMMultiLayerSymbolGenerated} = await import('./cIMMultiLayerSymbol.gb');
    return await buildDotNetCIMMultiLayerSymbolGenerated(jsObject);
}
