
export async function buildJsUniqueValue(dotNetObject: any): Promise<any> {
    let { buildJsUniqueValueGenerated } = await import('./uniqueValue.gb');
    return await buildJsUniqueValueGenerated(dotNetObject);
}     

export async function buildDotNetUniqueValue(jsObject: any): Promise<any> {
    let { buildDotNetUniqueValueGenerated } = await import('./uniqueValue.gb');
    return await buildDotNetUniqueValueGenerated(jsObject);
}
