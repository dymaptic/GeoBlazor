
export async function buildJsRasterShadedReliefResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterShadedReliefResultGenerated } = await import('./rasterShadedReliefResult.gb');
    return await buildJsRasterShadedReliefResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterShadedReliefResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRasterShadedReliefResultGenerated } = await import('./rasterShadedReliefResult.gb');
    return await buildDotNetRasterShadedReliefResultGenerated(jsObject, layerId, viewId);
}
