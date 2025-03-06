
export async function buildJsBuildingFilterBlockFilterMode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBuildingFilterBlockFilterModeGenerated } = await import('./buildingFilterBlockFilterMode.gb');
    return await buildJsBuildingFilterBlockFilterModeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBuildingFilterBlockFilterMode(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetBuildingFilterBlockFilterModeGenerated } = await import('./buildingFilterBlockFilterMode.gb');
    return await buildDotNetBuildingFilterBlockFilterModeGenerated(jsObject, layerId, viewId);
}
