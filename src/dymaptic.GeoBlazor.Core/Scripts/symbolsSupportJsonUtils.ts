
export async function buildJsSymbolsSupportJsonUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbolsSupportJsonUtilsGenerated } = await import('./symbolsSupportJsonUtils.gb');
    return await buildJsSymbolsSupportJsonUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSymbolsSupportJsonUtils(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSymbolsSupportJsonUtilsGenerated } = await import('./symbolsSupportJsonUtils.gb');
    return await buildDotNetSymbolsSupportJsonUtilsGenerated(jsObject, layerId, viewId);
}
