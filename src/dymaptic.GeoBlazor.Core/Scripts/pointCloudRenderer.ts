
export async function buildJsPointCloudRenderer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsPointCloudRendererGenerated } = await import('./pointCloudRenderer.gb');
    return await buildJsPointCloudRendererGenerated(dotNetObject, viewId);
}     

export async function buildDotNetPointCloudRenderer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPointCloudRendererGenerated } = await import('./pointCloudRenderer.gb');
    return await buildDotNetPointCloudRendererGenerated(jsObject, viewId);
}
