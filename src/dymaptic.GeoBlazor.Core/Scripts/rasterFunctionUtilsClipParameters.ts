
export async function buildJsRasterFunctionUtilsClipParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterFunctionUtilsClipParametersGenerated } = await import('./rasterFunctionUtilsClipParameters.gb');
    return await buildJsRasterFunctionUtilsClipParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterFunctionUtilsClipParameters(jsObject: any): Promise<any> {
    let { buildDotNetRasterFunctionUtilsClipParametersGenerated } = await import('./rasterFunctionUtilsClipParameters.gb');
    return await buildDotNetRasterFunctionUtilsClipParametersGenerated(jsObject);
}
