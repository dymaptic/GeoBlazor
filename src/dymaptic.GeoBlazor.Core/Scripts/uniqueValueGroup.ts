
export async function buildJsUniqueValueGroup(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsUniqueValueGroupGenerated } = await import('./uniqueValueGroup.gb');
    return await buildJsUniqueValueGroupGenerated(dotNetObject, viewId);
}     

export async function buildDotNetUniqueValueGroup(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetUniqueValueGroupGenerated } = await import('./uniqueValueGroup.gb');
    return await buildDotNetUniqueValueGroupGenerated(jsObject, viewId);
}
