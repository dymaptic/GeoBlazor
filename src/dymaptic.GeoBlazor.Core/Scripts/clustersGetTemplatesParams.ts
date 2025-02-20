export async function buildJsClustersGetTemplatesParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsClustersGetTemplatesParamsGenerated} = await import('./clustersGetTemplatesParams.gb');
    return await buildJsClustersGetTemplatesParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetClustersGetTemplatesParams(jsObject: any): Promise<any> {
    let {buildDotNetClustersGetTemplatesParamsGenerated} = await import('./clustersGetTemplatesParams.gb');
    return await buildDotNetClustersGetTemplatesParamsGenerated(jsObject);
}
