export async function buildJsRasterUniqueValuesResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRasterUniqueValuesResultGenerated} = await import('./rasterUniqueValuesResult.gb');
    return await buildJsRasterUniqueValuesResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRasterUniqueValuesResult(jsObject: any): Promise<any> {
    let {buildDotNetRasterUniqueValuesResultGenerated} = await import('./rasterUniqueValuesResult.gb');
    return await buildDotNetRasterUniqueValuesResultGenerated(jsObject);
}
