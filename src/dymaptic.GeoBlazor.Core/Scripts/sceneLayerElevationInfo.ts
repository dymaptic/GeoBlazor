
export async function buildJsSceneLayerElevationInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsSceneLayerElevationInfoGenerated } = await import('./sceneLayerElevationInfo.gb');
    return await buildJsSceneLayerElevationInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetSceneLayerElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSceneLayerElevationInfoGenerated } = await import('./sceneLayerElevationInfo.gb');
    return await buildDotNetSceneLayerElevationInfoGenerated(jsObject, viewId);
}
