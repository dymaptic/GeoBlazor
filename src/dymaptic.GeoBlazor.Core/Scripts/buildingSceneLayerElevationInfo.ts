
export async function buildJsBuildingSceneLayerElevationInfo(dotNetObject: any): Promise<any> {
    let { buildJsBuildingSceneLayerElevationInfoGenerated } = await import('./buildingSceneLayerElevationInfo.gb');
    return await buildJsBuildingSceneLayerElevationInfoGenerated(dotNetObject);
}     

export async function buildDotNetBuildingSceneLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetBuildingSceneLayerElevationInfoGenerated } = await import('./buildingSceneLayerElevationInfo.gb');
    return await buildDotNetBuildingSceneLayerElevationInfoGenerated(jsObject);
}
