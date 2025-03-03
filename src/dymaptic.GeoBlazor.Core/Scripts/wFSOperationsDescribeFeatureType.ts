
export async function buildJsWFSOperationsDescribeFeatureType(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWFSOperationsDescribeFeatureTypeGenerated } = await import('./wFSOperationsDescribeFeatureType.gb');
    return await buildJsWFSOperationsDescribeFeatureTypeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWFSOperationsDescribeFeatureType(jsObject: any): Promise<any> {
    let { buildDotNetWFSOperationsDescribeFeatureTypeGenerated } = await import('./wFSOperationsDescribeFeatureType.gb');
    return await buildDotNetWFSOperationsDescribeFeatureTypeGenerated(jsObject);
}
