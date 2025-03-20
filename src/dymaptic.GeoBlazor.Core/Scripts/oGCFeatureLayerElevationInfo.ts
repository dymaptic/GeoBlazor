
export async function buildJsOGCFeatureLayerElevationInfo(dotNetObject: any): Promise<any> {
    let { buildJsOGCFeatureLayerElevationInfoGenerated } = await import('./oGCFeatureLayerElevationInfo.gb');
    return await buildJsOGCFeatureLayerElevationInfoGenerated(dotNetObject);
}     

export async function buildDotNetOGCFeatureLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetOGCFeatureLayerElevationInfoGenerated } = await import('./oGCFeatureLayerElevationInfo.gb');
    return await buildDotNetOGCFeatureLayerElevationInfoGenerated(jsObject);
}
