
export async function buildJsViewpoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewpointGenerated } = await import('./viewpoint.gb');
    return await buildJsViewpointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewpoint(jsObject: any): Promise<any> {
    let { buildDotNetViewpointGenerated } = await import('./viewpoint.gb');
    return await buildDotNetViewpointGenerated(jsObject);
}
