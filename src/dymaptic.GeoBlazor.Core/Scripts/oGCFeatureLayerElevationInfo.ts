
export async function buildJsOGCFeatureLayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOGCFeatureLayerElevationInfoGenerated } = await import('./oGCFeatureLayerElevationInfo.gb');
    return await buildJsOGCFeatureLayerElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOGCFeatureLayerElevationInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetOGCFeatureLayerElevationInfoGenerated } = await import('./oGCFeatureLayerElevationInfo.gb');
    return await buildDotNetOGCFeatureLayerElevationInfoGenerated(jsObject, layerId, viewId);
}
