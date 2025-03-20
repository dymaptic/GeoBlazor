
export async function buildJsPointCloudRenderer(dotNetObject: any): Promise<any> {
    let { buildJsPointCloudRendererGenerated } = await import('./pointCloudRenderer.gb');
    return await buildJsPointCloudRendererGenerated(dotNetObject);
}     

export async function buildDotNetPointCloudRenderer(jsObject: any): Promise<any> {
    let { buildDotNetPointCloudRendererGenerated } = await import('./pointCloudRenderer.gb');
    return await buildDotNetPointCloudRendererGenerated(jsObject);
}
