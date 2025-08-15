
export async function buildJsOGCFeatureLayerElevationInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsOGCFeatureLayerElevationInfoGenerated } = await import('./oGCFeatureLayerElevationInfo.gb');
    return await buildJsOGCFeatureLayerElevationInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetOGCFeatureLayerElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetOGCFeatureLayerElevationInfoGenerated } = await import('./oGCFeatureLayerElevationInfo.gb');
    return await buildDotNetOGCFeatureLayerElevationInfoGenerated(jsObject, viewId);
}
