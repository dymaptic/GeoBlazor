
export async function buildJsPointCloudRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointCloudRendererGenerated } = await import('./pointCloudRenderer.gb');
    return await buildJsPointCloudRendererGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointCloudRenderer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPointCloudRendererGenerated } = await import('./pointCloudRenderer.gb');
    return await buildDotNetPointCloudRendererGenerated(jsObject, layerId, viewId);
}
