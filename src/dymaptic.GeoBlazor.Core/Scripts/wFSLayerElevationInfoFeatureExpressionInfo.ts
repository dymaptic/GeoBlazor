
export async function buildJsWFSLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsWFSLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./wFSLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsWFSLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetWFSLayerElevationInfoFeatureExpressionInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetWFSLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./wFSLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetWFSLayerElevationInfoFeatureExpressionInfoGenerated(jsObject, viewId);
}
