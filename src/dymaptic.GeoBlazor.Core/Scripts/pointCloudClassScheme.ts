
export async function buildJsPointCloudClassScheme(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointCloudClassSchemeGenerated } = await import('./pointCloudClassScheme.gb');
    return await buildJsPointCloudClassSchemeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointCloudClassScheme(jsObject: any): Promise<any> {
    let { buildDotNetPointCloudClassSchemeGenerated } = await import('./pointCloudClassScheme.gb');
    return await buildDotNetPointCloudClassSchemeGenerated(jsObject);
}
