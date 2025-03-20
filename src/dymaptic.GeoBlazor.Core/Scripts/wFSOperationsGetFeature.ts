
export async function buildJsWFSOperationsGetFeature(dotNetObject: any): Promise<any> {
    let { buildJsWFSOperationsGetFeatureGenerated } = await import('./wFSOperationsGetFeature.gb');
    return await buildJsWFSOperationsGetFeatureGenerated(dotNetObject);
}     

export async function buildDotNetWFSOperationsGetFeature(jsObject: any): Promise<any> {
    let { buildDotNetWFSOperationsGetFeatureGenerated } = await import('./wFSOperationsGetFeature.gb');
    return await buildDotNetWFSOperationsGetFeatureGenerated(jsObject);
}
