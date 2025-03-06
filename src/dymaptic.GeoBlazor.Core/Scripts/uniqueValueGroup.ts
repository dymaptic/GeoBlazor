
export async function buildJsUniqueValueGroup(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUniqueValueGroupGenerated } = await import('./uniqueValueGroup.gb');
    return await buildJsUniqueValueGroupGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUniqueValueGroup(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetUniqueValueGroupGenerated } = await import('./uniqueValueGroup.gb');
    return await buildDotNetUniqueValueGroupGenerated(jsObject, layerId, viewId);
}
