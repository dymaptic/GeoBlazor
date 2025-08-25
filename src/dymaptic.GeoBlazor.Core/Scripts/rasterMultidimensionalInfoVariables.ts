
export async function buildJsRasterMultidimensionalInfoVariables(dotNetObject: any): Promise<any> {
    let { buildJsRasterMultidimensionalInfoVariablesGenerated } = await import('./rasterMultidimensionalInfoVariables.gb');
    return await buildJsRasterMultidimensionalInfoVariablesGenerated(dotNetObject);
}     

export async function buildDotNetRasterMultidimensionalInfoVariables(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetRasterMultidimensionalInfoVariablesGenerated } = await import('./rasterMultidimensionalInfoVariables.gb');
    return await buildDotNetRasterMultidimensionalInfoVariablesGenerated(jsObject, viewId);
}
