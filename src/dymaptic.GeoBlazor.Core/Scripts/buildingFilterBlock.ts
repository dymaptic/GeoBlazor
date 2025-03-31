
export async function buildJsBuildingFilterBlock(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBuildingFilterBlockGenerated } = await import('./buildingFilterBlock.gb');
    return await buildJsBuildingFilterBlockGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBuildingFilterBlock(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetBuildingFilterBlockGenerated } = await import('./buildingFilterBlock.gb');
    return await buildDotNetBuildingFilterBlockGenerated(jsObject, layerId, viewId);
}
