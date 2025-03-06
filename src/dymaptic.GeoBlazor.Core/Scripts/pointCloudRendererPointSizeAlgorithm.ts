
export async function buildJsPointCloudRendererPointSizeAlgorithm(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointCloudRendererPointSizeAlgorithmGenerated } = await import('./pointCloudRendererPointSizeAlgorithm.gb');
    return await buildJsPointCloudRendererPointSizeAlgorithmGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointCloudRendererPointSizeAlgorithm(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPointCloudRendererPointSizeAlgorithmGenerated } = await import('./pointCloudRendererPointSizeAlgorithm.gb');
    return await buildDotNetPointCloudRendererPointSizeAlgorithmGenerated(jsObject, layerId, viewId);
}
