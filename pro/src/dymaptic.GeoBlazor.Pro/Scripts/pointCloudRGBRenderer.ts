
export async function buildJsPointCloudRGBRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointCloudRGBRendererGenerated } = await import('./pointCloudRGBRenderer.gb');
    return await buildJsPointCloudRGBRendererGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointCloudRGBRenderer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPointCloudRGBRendererGenerated } = await import('./pointCloudRGBRenderer.gb');
    return await buildDotNetPointCloudRGBRendererGenerated(jsObject, layerId, viewId);
}
