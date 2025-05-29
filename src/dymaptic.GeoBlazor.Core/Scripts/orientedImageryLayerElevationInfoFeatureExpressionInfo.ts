
export async function buildJsOrientedImageryLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOrientedImageryLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./orientedImageryLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsOrientedImageryLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOrientedImageryLayerElevationInfoFeatureExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetOrientedImageryLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./orientedImageryLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetOrientedImageryLayerElevationInfoFeatureExpressionInfoGenerated(jsObject);
}
