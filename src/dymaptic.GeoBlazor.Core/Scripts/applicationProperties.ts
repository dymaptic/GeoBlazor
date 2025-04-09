
export async function buildJsApplicationProperties(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsApplicationPropertiesGenerated } = await import('./applicationProperties.gb');
    return await buildJsApplicationPropertiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetApplicationProperties(jsObject: any): Promise<any> {
    let { buildDotNetApplicationPropertiesGenerated } = await import('./applicationProperties.gb');
    return await buildDotNetApplicationPropertiesGenerated(jsObject);
}
