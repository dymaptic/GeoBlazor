
export async function buildJsSceneLayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneLayerElevationInfoGenerated } = await import('./sceneLayerElevationInfo.gb');
    return await buildJsSceneLayerElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneLayerElevationInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSceneLayerElevationInfoGenerated } = await import('./sceneLayerElevationInfo.gb');
    return await buildDotNetSceneLayerElevationInfoGenerated(jsObject, layerId, viewId);
}
