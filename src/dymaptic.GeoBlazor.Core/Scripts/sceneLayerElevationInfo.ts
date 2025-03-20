
export async function buildJsSceneLayerElevationInfo(dotNetObject: any): Promise<any> {
    let { buildJsSceneLayerElevationInfoGenerated } = await import('./sceneLayerElevationInfo.gb');
    return await buildJsSceneLayerElevationInfoGenerated(dotNetObject);
}     

export async function buildDotNetSceneLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetSceneLayerElevationInfoGenerated } = await import('./sceneLayerElevationInfo.gb');
    return await buildDotNetSceneLayerElevationInfoGenerated(jsObject);
}
