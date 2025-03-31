
export async function buildJsRasterFunctionConstants(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterFunctionConstantsGenerated } = await import('./rasterFunctionConstants.gb');
    return await buildJsRasterFunctionConstantsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterFunctionConstants(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRasterFunctionConstantsGenerated } = await import('./rasterFunctionConstants.gb');
    return await buildDotNetRasterFunctionConstantsGenerated(jsObject, layerId, viewId);
}
