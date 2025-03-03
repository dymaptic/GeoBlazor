
export async function buildJsUniqueValuesResultUniqueValueInfos(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUniqueValuesResultUniqueValueInfosGenerated } = await import('./uniqueValuesResultUniqueValueInfos.gb');
    return await buildJsUniqueValuesResultUniqueValueInfosGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUniqueValuesResultUniqueValueInfos(jsObject: any): Promise<any> {
    let { buildDotNetUniqueValuesResultUniqueValueInfosGenerated } = await import('./uniqueValuesResultUniqueValueInfos.gb');
    return await buildDotNetUniqueValuesResultUniqueValueInfosGenerated(jsObject);
}
