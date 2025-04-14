
export async function buildJsRasterMultidimensionalInfoVariables(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterMultidimensionalInfoVariablesGenerated } = await import('./rasterMultidimensionalInfoVariables.gb');
    return await buildJsRasterMultidimensionalInfoVariablesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterMultidimensionalInfoVariables(jsObject: any): Promise<any> {
    let { buildDotNetRasterMultidimensionalInfoVariablesGenerated } = await import('./rasterMultidimensionalInfoVariables.gb');
    return await buildDotNetRasterMultidimensionalInfoVariablesGenerated(jsObject);
}
