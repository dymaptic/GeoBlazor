
export async function buildJsGeoJSONLayerElevationInfoFeatureExpressionInfo(dotNetObject: any): Promise<any> {
    let { buildJsGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./geoJSONLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject);
}     

export async function buildDotNetGeoJSONLayerElevationInfoFeatureExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./geoJSONLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated(jsObject);
}
