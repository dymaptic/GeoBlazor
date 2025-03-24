
export async function buildJsUniqueValueInfo(dotNetObject: any): Promise<any> {
    let { buildJsUniqueValueInfoGenerated } = await import('./uniqueValueInfo.gb');
    return await buildJsUniqueValueInfoGenerated(dotNetObject);
}     

export async function buildDotNetUniqueValueInfo(jsObject: any): Promise<any> {
    let { buildDotNetUniqueValueInfoGenerated } = await import('./uniqueValueInfo.gb');
    return await buildDotNetUniqueValueInfoGenerated(jsObject);
}
