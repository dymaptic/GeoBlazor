
export async function buildJsClustersSchemes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClustersSchemesGenerated } = await import('./clustersSchemes.gb');
    return await buildJsClustersSchemesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClustersSchemes(jsObject: any): Promise<any> {
    let { buildDotNetClustersSchemesGenerated } = await import('./clustersSchemes.gb');
    return await buildDotNetClustersSchemesGenerated(jsObject);
}
