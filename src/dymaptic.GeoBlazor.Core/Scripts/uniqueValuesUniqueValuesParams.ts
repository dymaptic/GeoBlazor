export async function buildJsUniqueValuesUniqueValuesParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUniqueValuesUniqueValuesParamsGenerated } = await import('./uniqueValuesUniqueValuesParams.gb');
    return await buildJsUniqueValuesUniqueValuesParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetUniqueValuesUniqueValuesParams(jsObject: any): Promise<any> {
    let { buildDotNetUniqueValuesUniqueValuesParamsGenerated } = await import('./uniqueValuesUniqueValuesParams.gb');
    return await buildDotNetUniqueValuesUniqueValuesParamsGenerated(jsObject);
}
