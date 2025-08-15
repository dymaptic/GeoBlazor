
export async function buildJsFeatureLayerBaseElevationInfoFeatureExpressionInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsFeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated } = await import('./featureLayerBaseElevationInfoFeatureExpressionInfo.gb');
    return await buildJsFeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetFeatureLayerBaseElevationInfoFeatureExpressionInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated } = await import('./featureLayerBaseElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetFeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated(jsObject, viewId);
}
