
export async function buildJsCSVLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCSVLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./cSVLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsCSVLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCSVLayerElevationInfoFeatureExpressionInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCSVLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./cSVLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetCSVLayerElevationInfoFeatureExpressionInfoGenerated(jsObject, layerId, viewId);
}
