
export async function buildJsUniqueValueInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUniqueValueInfoGenerated } = await import('./uniqueValueInfo.gb');
    return await buildJsUniqueValueInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUniqueValueInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetUniqueValueInfoGenerated } = await import('./uniqueValueInfo.gb');
    return await buildDotNetUniqueValueInfoGenerated(jsObject, layerId, viewId);
}
