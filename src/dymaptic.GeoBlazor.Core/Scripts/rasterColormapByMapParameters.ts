
export async function buildJsRasterColormapByMapParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterColormapByMapParametersGenerated } = await import('./rasterColormapByMapParameters.gb');
    return await buildJsRasterColormapByMapParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterColormapByMapParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRasterColormapByMapParametersGenerated } = await import('./rasterColormapByMapParameters.gb');
    return await buildDotNetRasterColormapByMapParametersGenerated(jsObject, layerId, viewId);
}
