
export async function buildJsStreamLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsStreamLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./streamLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsStreamLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetStreamLayerElevationInfoFeatureExpressionInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetStreamLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./streamLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetStreamLayerElevationInfoFeatureExpressionInfoGenerated(jsObject, viewId);
}
