
export async function buildJsRasterColormapResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterColormapResultGenerated } = await import('./rasterColormapResult.gb');
    return await buildJsRasterColormapResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterColormapResult(jsObject: any): Promise<any> {
    let { buildDotNetRasterColormapResultGenerated } = await import('./rasterColormapResult.gb');
    return await buildDotNetRasterColormapResultGenerated(jsObject);
}
