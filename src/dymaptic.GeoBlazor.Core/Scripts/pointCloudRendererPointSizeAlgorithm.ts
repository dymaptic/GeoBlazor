
export async function buildJsPointCloudRendererPointSizeAlgorithm(dotNetObject: any): Promise<any> {
    let { buildJsPointCloudRendererPointSizeAlgorithmGenerated } = await import('./pointCloudRendererPointSizeAlgorithm.gb');
    return await buildJsPointCloudRendererPointSizeAlgorithmGenerated(dotNetObject);
}     

export async function buildDotNetPointCloudRendererPointSizeAlgorithm(jsObject: any): Promise<any> {
    let { buildDotNetPointCloudRendererPointSizeAlgorithmGenerated } = await import('./pointCloudRendererPointSizeAlgorithm.gb');
    return await buildDotNetPointCloudRendererPointSizeAlgorithmGenerated(jsObject);
}
