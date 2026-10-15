
export async function buildJsRasterShadedReliefRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterShadedReliefRendererGenerated } = await import('./rasterShadedReliefRenderer.gb');
    return await buildJsRasterShadedReliefRendererGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterShadedReliefRenderer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRasterShadedReliefRendererGenerated } = await import('./rasterShadedReliefRenderer.gb');
    return await buildDotNetRasterShadedReliefRendererGenerated(jsObject, layerId, viewId);
}
