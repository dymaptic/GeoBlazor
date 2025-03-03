
export async function buildJsBuildingSceneLayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBuildingSceneLayerElevationInfoGenerated } = await import('./buildingSceneLayerElevationInfo.gb');
    return await buildJsBuildingSceneLayerElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBuildingSceneLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetBuildingSceneLayerElevationInfoGenerated } = await import('./buildingSceneLayerElevationInfo.gb');
    return await buildDotNetBuildingSceneLayerElevationInfoGenerated(jsObject);
}
