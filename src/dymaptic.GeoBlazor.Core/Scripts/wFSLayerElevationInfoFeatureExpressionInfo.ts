
export async function buildJsWFSLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWFSLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./wFSLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsWFSLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWFSLayerElevationInfoFeatureExpressionInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetWFSLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./wFSLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetWFSLayerElevationInfoFeatureExpressionInfoGenerated(jsObject, layerId, viewId);
}
