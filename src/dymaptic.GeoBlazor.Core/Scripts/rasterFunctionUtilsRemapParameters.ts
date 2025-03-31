
export async function buildJsRasterFunctionUtilsRemapParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterFunctionUtilsRemapParametersGenerated } = await import('./rasterFunctionUtilsRemapParameters.gb');
    return await buildJsRasterFunctionUtilsRemapParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterFunctionUtilsRemapParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRasterFunctionUtilsRemapParametersGenerated } = await import('./rasterFunctionUtilsRemapParameters.gb');
    return await buildDotNetRasterFunctionUtilsRemapParametersGenerated(jsObject, layerId, viewId);
}
