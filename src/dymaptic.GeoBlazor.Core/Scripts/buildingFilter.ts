
export async function buildJsBuildingFilter(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBuildingFilterGenerated } = await import('./buildingFilter.gb');
    return await buildJsBuildingFilterGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBuildingFilter(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetBuildingFilterGenerated } = await import('./buildingFilter.gb');
    return await buildDotNetBuildingFilterGenerated(jsObject, layerId, viewId);
}
