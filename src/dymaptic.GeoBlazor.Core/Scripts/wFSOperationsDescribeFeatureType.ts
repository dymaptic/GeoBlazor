
export async function buildJsWFSOperationsDescribeFeatureType(dotNetObject: any): Promise<any> {
    let { buildJsWFSOperationsDescribeFeatureTypeGenerated } = await import('./wFSOperationsDescribeFeatureType.gb');
    return await buildJsWFSOperationsDescribeFeatureTypeGenerated(dotNetObject);
}     

export async function buildDotNetWFSOperationsDescribeFeatureType(jsObject: any): Promise<any> {
    let { buildDotNetWFSOperationsDescribeFeatureTypeGenerated } = await import('./wFSOperationsDescribeFeatureType.gb');
    return await buildDotNetWFSOperationsDescribeFeatureTypeGenerated(jsObject);
}
