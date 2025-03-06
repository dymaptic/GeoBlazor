
export async function buildJsUniqueValueClass(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUniqueValueClassGenerated } = await import('./uniqueValueClass.gb');
    return await buildJsUniqueValueClassGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUniqueValueClass(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetUniqueValueClassGenerated } = await import('./uniqueValueClass.gb');
    return await buildDotNetUniqueValueClassGenerated(jsObject, layerId, viewId);
}
