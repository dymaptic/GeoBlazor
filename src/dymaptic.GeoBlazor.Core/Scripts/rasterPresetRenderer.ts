
export async function buildJsRasterPresetRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterPresetRendererGenerated } = await import('./rasterPresetRenderer.gb');
    return await buildJsRasterPresetRendererGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterPresetRenderer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetRasterPresetRendererGenerated } = await import('./rasterPresetRenderer.gb');
    return await buildDotNetRasterPresetRendererGenerated(jsObject, viewId);
}
