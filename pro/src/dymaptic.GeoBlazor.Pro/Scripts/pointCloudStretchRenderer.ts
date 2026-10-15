
export async function buildJsPointCloudStretchRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointCloudStretchRendererGenerated } = await import('./pointCloudStretchRenderer.gb');
    return await buildJsPointCloudStretchRendererGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointCloudStretchRenderer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPointCloudStretchRendererGenerated } = await import('./pointCloudStretchRenderer.gb');
    return await buildDotNetPointCloudStretchRendererGenerated(jsObject, layerId, viewId);
}
