export async function buildJsClustersScheme(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsClustersSchemeGenerated} = await import('./clustersScheme.gb');
    return await buildJsClustersSchemeGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetClustersScheme(jsObject: any): Promise<any> {
    let {buildDotNetClustersSchemeGenerated} = await import('./clustersScheme.gb');
    return await buildDotNetClustersSchemeGenerated(jsObject);
}
