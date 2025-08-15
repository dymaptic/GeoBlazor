
export async function buildJsUniqueValue(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsUniqueValueGenerated } = await import('./uniqueValue.gb');
    return await buildJsUniqueValueGenerated(dotNetObject, viewId);
}     

export async function buildDotNetUniqueValue(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetUniqueValueGenerated } = await import('./uniqueValue.gb');
    return await buildDotNetUniqueValueGenerated(jsObject, viewId);
}
