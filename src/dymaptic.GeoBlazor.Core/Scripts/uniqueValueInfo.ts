
export async function buildJsUniqueValueInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsUniqueValueInfoGenerated } = await import('./uniqueValueInfo.gb');
    return await buildJsUniqueValueInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetUniqueValueInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetUniqueValueInfoGenerated } = await import('./uniqueValueInfo.gb');
    return await buildDotNetUniqueValueInfoGenerated(jsObject, viewId);
}
