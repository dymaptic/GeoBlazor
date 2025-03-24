
export async function buildJsUniqueValueGroup(dotNetObject: any): Promise<any> {
    let { buildJsUniqueValueGroupGenerated } = await import('./uniqueValueGroup.gb');
    return await buildJsUniqueValueGroupGenerated(dotNetObject);
}     

export async function buildDotNetUniqueValueGroup(jsObject: any): Promise<any> {
    let { buildDotNetUniqueValueGroupGenerated } = await import('./uniqueValueGroup.gb');
    return await buildDotNetUniqueValueGroupGenerated(jsObject);
}
