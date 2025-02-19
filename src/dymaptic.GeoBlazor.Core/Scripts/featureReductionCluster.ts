
export async function buildJsFeatureReductionCluster(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureReductionClusterGenerated } = await import('./featureReductionCluster.gb');
    return await buildJsFeatureReductionClusterGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureReductionCluster(jsObject: any): Promise<any> {
    let { buildDotNetFeatureReductionClusterGenerated } = await import('./featureReductionCluster.gb');
    return await buildDotNetFeatureReductionClusterGenerated(jsObject);
}
