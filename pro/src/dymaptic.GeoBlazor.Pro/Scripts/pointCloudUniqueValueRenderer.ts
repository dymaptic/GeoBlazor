
export async function buildJsPointCloudUniqueValueRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointCloudUniqueValueRendererGenerated } = await import('./pointCloudUniqueValueRenderer.gb');
    return await buildJsPointCloudUniqueValueRendererGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointCloudUniqueValueRenderer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPointCloudUniqueValueRendererGenerated } = await import('./pointCloudUniqueValueRenderer.gb');
    return await buildDotNetPointCloudUniqueValueRendererGenerated(jsObject, layerId, viewId);
}
