
export async function buildJsGeoJSONLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./geoJSONLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeoJSONLayerElevationInfoFeatureExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./geoJSONLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated(jsObject);
}
