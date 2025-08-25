
export async function buildJsGraphicsLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsGraphicsLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./graphicsLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsGraphicsLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetGraphicsLayerElevationInfoFeatureExpressionInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetGraphicsLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./graphicsLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetGraphicsLayerElevationInfoFeatureExpressionInfoGenerated(jsObject, viewId);
}
