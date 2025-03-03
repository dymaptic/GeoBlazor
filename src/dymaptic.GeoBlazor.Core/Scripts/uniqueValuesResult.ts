
export async function buildJsUniqueValuesResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUniqueValuesResultGenerated } = await import('./uniqueValuesResult.gb');
    return await buildJsUniqueValuesResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUniqueValuesResult(jsObject: any): Promise<any> {
    let { buildDotNetUniqueValuesResultGenerated } = await import('./uniqueValuesResult.gb');
    return await buildDotNetUniqueValuesResultGenerated(jsObject);
}
