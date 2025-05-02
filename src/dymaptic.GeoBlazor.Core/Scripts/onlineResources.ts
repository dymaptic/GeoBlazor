
export async function buildJsOnlineResources(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOnlineResourcesGenerated } = await import('./onlineResources.gb');
    return await buildJsOnlineResourcesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOnlineResources(jsObject: any): Promise<any> {
    let { buildDotNetOnlineResourcesGenerated } = await import('./onlineResources.gb');
    return await buildDotNetOnlineResourcesGenerated(jsObject);
}
