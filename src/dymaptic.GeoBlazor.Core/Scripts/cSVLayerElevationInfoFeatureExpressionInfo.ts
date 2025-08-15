
export async function buildJsCSVLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsCSVLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./cSVLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsCSVLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetCSVLayerElevationInfoFeatureExpressionInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetCSVLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./cSVLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetCSVLayerElevationInfoFeatureExpressionInfoGenerated(jsObject, viewId);
}
