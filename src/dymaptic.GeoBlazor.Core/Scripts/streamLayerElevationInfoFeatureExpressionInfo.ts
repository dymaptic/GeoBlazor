
export async function buildJsStreamLayerElevationInfoFeatureExpressionInfo(dotNetObject: any): Promise<any> {
    let { buildJsStreamLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./streamLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsStreamLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject);
}     

export async function buildDotNetStreamLayerElevationInfoFeatureExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetStreamLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./streamLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetStreamLayerElevationInfoFeatureExpressionInfoGenerated(jsObject);
}
