
export async function buildJsClustersGetLabelSchemesParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClustersGetLabelSchemesParamsGenerated } = await import('./clustersGetLabelSchemesParams.gb');
    return await buildJsClustersGetLabelSchemesParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClustersGetLabelSchemesParams(jsObject: any): Promise<any> {
    let { buildDotNetClustersGetLabelSchemesParamsGenerated } = await import('./clustersGetLabelSchemesParams.gb');
    return await buildDotNetClustersGetLabelSchemesParamsGenerated(jsObject);
}
