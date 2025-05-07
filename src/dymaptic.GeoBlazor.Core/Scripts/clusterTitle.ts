
export async function buildJsClusterTitle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClusterTitleGenerated } = await import('./clusterTitle.gb');
    return await buildJsClusterTitleGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClusterTitle(jsObject: any): Promise<any> {
    let { buildDotNetClusterTitleGenerated } = await import('./clusterTitle.gb');
    return await buildDotNetClusterTitleGenerated(jsObject);
}
