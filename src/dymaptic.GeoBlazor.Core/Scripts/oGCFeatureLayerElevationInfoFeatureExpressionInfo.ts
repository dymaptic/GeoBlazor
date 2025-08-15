
export async function buildJsOGCFeatureLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsOGCFeatureLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./oGCFeatureLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsOGCFeatureLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetOGCFeatureLayerElevationInfoFeatureExpressionInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetOGCFeatureLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./oGCFeatureLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetOGCFeatureLayerElevationInfoFeatureExpressionInfoGenerated(jsObject, viewId);
}
