
export async function buildJsGeoJSONLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./geoJSONLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetGeoJSONLayerElevationInfoFeatureExpressionInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./geoJSONLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated(jsObject, viewId);
}
