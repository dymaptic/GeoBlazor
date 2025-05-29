
export async function buildJsWebsceneApplicationProperties(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebsceneApplicationPropertiesGenerated } = await import('./websceneApplicationProperties.gb');
    return await buildJsWebsceneApplicationPropertiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebsceneApplicationProperties(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetWebsceneApplicationPropertiesGenerated } = await import('./websceneApplicationProperties.gb');
    return await buildDotNetWebsceneApplicationPropertiesGenerated(jsObject, layerId, viewId);
}
