
export async function buildJsFetchResourcesResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFetchResourcesResultGenerated } = await import('./fetchResourcesResult.gb');
    return await buildJsFetchResourcesResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFetchResourcesResult(jsObject: any): Promise<any> {
    let { buildDotNetFetchResourcesResultGenerated } = await import('./fetchResourcesResult.gb');
    return await buildDotNetFetchResourcesResultGenerated(jsObject);
}
