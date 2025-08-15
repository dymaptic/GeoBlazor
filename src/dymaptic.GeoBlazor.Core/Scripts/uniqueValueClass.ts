
export async function buildJsUniqueValueClass(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsUniqueValueClassGenerated } = await import('./uniqueValueClass.gb');
    return await buildJsUniqueValueClassGenerated(dotNetObject, viewId);
}     

export async function buildDotNetUniqueValueClass(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetUniqueValueClassGenerated } = await import('./uniqueValueClass.gb');
    return await buildDotNetUniqueValueClassGenerated(jsObject, viewId);
}
