
export async function buildJsStreamLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStreamLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./streamLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsStreamLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetStreamLayerElevationInfoFeatureExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetStreamLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./streamLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetStreamLayerElevationInfoFeatureExpressionInfoGenerated(jsObject);
}
