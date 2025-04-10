
export async function buildJsWebsceneInitialViewProperties(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebsceneInitialViewPropertiesGenerated } = await import('./websceneInitialViewProperties.gb');
    return await buildJsWebsceneInitialViewPropertiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebsceneInitialViewProperties(jsObject: any): Promise<any> {
    let { buildDotNetWebsceneInitialViewPropertiesGenerated } = await import('./websceneInitialViewProperties.gb');
    return await buildDotNetWebsceneInitialViewPropertiesGenerated(jsObject);
}
