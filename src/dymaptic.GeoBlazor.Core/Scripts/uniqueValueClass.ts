
export async function buildJsUniqueValueClass(dotNetObject: any): Promise<any> {
    let { buildJsUniqueValueClassGenerated } = await import('./uniqueValueClass.gb');
    return await buildJsUniqueValueClassGenerated(dotNetObject);
}     

export async function buildDotNetUniqueValueClass(jsObject: any): Promise<any> {
    let { buildDotNetUniqueValueClassGenerated } = await import('./uniqueValueClass.gb');
    return await buildDotNetUniqueValueClassGenerated(jsObject);
}
