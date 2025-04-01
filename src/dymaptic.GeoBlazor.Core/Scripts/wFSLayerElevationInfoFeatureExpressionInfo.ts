
export async function buildJsWFSLayerElevationInfoFeatureExpressionInfo(dotNetObject: any): Promise<any> {
    let { buildJsWFSLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./wFSLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsWFSLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject);
}     

export async function buildDotNetWFSLayerElevationInfoFeatureExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetWFSLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./wFSLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetWFSLayerElevationInfoFeatureExpressionInfoGenerated(jsObject);
}
