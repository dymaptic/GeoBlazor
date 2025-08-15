
export async function buildJsRasterMultidimensionalInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterMultidimensionalInfoGenerated } = await import('./rasterMultidimensionalInfo.gb');
    return await buildJsRasterMultidimensionalInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterMultidimensionalInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetRasterMultidimensionalInfoGenerated } = await import('./rasterMultidimensionalInfo.gb');
    return await buildDotNetRasterMultidimensionalInfoGenerated(jsObject, viewId);
}
