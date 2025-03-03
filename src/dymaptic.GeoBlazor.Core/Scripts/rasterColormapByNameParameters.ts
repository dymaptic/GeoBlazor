
export async function buildJsRasterColormapByNameParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterColormapByNameParametersGenerated } = await import('./rasterColormapByNameParameters.gb');
    return await buildJsRasterColormapByNameParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterColormapByNameParameters(jsObject: any): Promise<any> {
    let { buildDotNetRasterColormapByNameParametersGenerated } = await import('./rasterColormapByNameParameters.gb');
    return await buildDotNetRasterColormapByNameParametersGenerated(jsObject);
}
