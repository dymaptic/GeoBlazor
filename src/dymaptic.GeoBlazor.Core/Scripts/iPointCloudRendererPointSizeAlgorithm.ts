
export async function buildJsIPointCloudRendererPointSizeAlgorithm(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIPointCloudRendererPointSizeAlgorithmGenerated } = await import('./iPointCloudRendererPointSizeAlgorithm.gb');
    return await buildJsIPointCloudRendererPointSizeAlgorithmGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIPointCloudRendererPointSizeAlgorithm(jsObject: any): Promise<any> {
    let { buildDotNetIPointCloudRendererPointSizeAlgorithmGenerated } = await import('./iPointCloudRendererPointSizeAlgorithm.gb');
    return await buildDotNetIPointCloudRendererPointSizeAlgorithmGenerated(jsObject);
}
