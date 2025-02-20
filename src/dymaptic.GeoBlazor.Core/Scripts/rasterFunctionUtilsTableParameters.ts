export async function buildJsRasterFunctionUtilsTableParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRasterFunctionUtilsTableParametersGenerated} = await import('./rasterFunctionUtilsTableParameters.gb');
    return await buildJsRasterFunctionUtilsTableParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRasterFunctionUtilsTableParameters(jsObject: any): Promise<any> {
    let {buildDotNetRasterFunctionUtilsTableParametersGenerated} = await import('./rasterFunctionUtilsTableParameters.gb');
    return await buildDotNetRasterFunctionUtilsTableParametersGenerated(jsObject);
}
