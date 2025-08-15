
export async function buildJsPointCloudFilter(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointCloudFilterGenerated } = await import('./pointCloudFilter.gb');
    return await buildJsPointCloudFilterGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointCloudFilter(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPointCloudFilterGenerated } = await import('./pointCloudFilter.gb');
    return await buildDotNetPointCloudFilterGenerated(jsObject, viewId);
}
