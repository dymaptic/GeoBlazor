
export async function buildJsFeatureLayerBaseElevationInfoFeatureExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated } = await import('./featureLayerBaseElevationInfoFeatureExpressionInfo.gb');
    return await buildJsFeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureLayerBaseElevationInfoFeatureExpressionInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated } = await import('./featureLayerBaseElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetFeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated(jsObject, layerId, viewId);
}
