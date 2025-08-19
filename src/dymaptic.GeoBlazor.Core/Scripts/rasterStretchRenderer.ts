
export async function buildJsRasterStretchRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterStretchRendererGenerated } = await import('./rasterStretchRenderer.gb');
    return await buildJsRasterStretchRendererGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterStretchRenderer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetRasterStretchRendererGenerated } = await import('./rasterStretchRenderer.gb');
    return await buildDotNetRasterStretchRendererGenerated(jsObject, viewId);
}
