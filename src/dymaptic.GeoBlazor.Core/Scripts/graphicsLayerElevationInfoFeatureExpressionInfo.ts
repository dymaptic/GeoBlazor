
export async function buildJsGraphicsLayerElevationInfoFeatureExpressionInfo(dotNetObject: any): Promise<any> {
    let { buildJsGraphicsLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./graphicsLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsGraphicsLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject);
}     

export async function buildDotNetGraphicsLayerElevationInfoFeatureExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetGraphicsLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./graphicsLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetGraphicsLayerElevationInfoFeatureExpressionInfoGenerated(jsObject);
}
