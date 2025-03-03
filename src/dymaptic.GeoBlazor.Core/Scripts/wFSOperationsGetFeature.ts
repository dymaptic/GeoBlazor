
export async function buildJsWFSOperationsGetFeature(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWFSOperationsGetFeatureGenerated } = await import('./wFSOperationsGetFeature.gb');
    return await buildJsWFSOperationsGetFeatureGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWFSOperationsGetFeature(jsObject: any): Promise<any> {
    let { buildDotNetWFSOperationsGetFeatureGenerated } = await import('./wFSOperationsGetFeature.gb');
    return await buildDotNetWFSOperationsGetFeatureGenerated(jsObject);
}
