
export async function buildJsOGCFeatureLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOGCFeatureLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./oGCFeatureLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsOGCFeatureLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOGCFeatureLayerElevationInfoFeatureExpressionInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetOGCFeatureLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./oGCFeatureLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetOGCFeatureLayerElevationInfoFeatureExpressionInfoGenerated(jsObject, layerId, viewId);
}
