
export async function buildJsRasterMultidimensionalInfo(dotNetObject: any): Promise<any> {
    let { buildJsRasterMultidimensionalInfoGenerated } = await import('./rasterMultidimensionalInfo.gb');
    return await buildJsRasterMultidimensionalInfoGenerated(dotNetObject);
}     

export async function buildDotNetRasterMultidimensionalInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetRasterMultidimensionalInfoGenerated } = await import('./rasterMultidimensionalInfo.gb');
    return await buildDotNetRasterMultidimensionalInfoGenerated(jsObject, viewId);
}
