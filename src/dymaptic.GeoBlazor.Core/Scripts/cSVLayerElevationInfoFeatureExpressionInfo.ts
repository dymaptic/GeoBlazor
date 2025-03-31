
export async function buildJsCSVLayerElevationInfoFeatureExpressionInfo(dotNetObject: any): Promise<any> {
    let { buildJsCSVLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./cSVLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsCSVLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject);
}     

export async function buildDotNetCSVLayerElevationInfoFeatureExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetCSVLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./cSVLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetCSVLayerElevationInfoFeatureExpressionInfoGenerated(jsObject);
}
