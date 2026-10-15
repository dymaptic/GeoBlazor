
export async function buildJsPointCloudClassBreaksRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointCloudClassBreaksRendererGenerated } = await import('./pointCloudClassBreaksRenderer.gb');
    return await buildJsPointCloudClassBreaksRendererGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointCloudClassBreaksRenderer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPointCloudClassBreaksRendererGenerated } = await import('./pointCloudClassBreaksRenderer.gb');
    return await buildDotNetPointCloudClassBreaksRendererGenerated(jsObject, layerId, viewId);
}
