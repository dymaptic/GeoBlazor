
export async function buildJsGeoJSONLayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeoJSONLayerElevationInfoGenerated } = await import('./geoJSONLayerElevationInfo.gb');
    return await buildJsGeoJSONLayerElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeoJSONLayerElevationInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetGeoJSONLayerElevationInfoGenerated } = await import('./geoJSONLayerElevationInfo.gb');
    return await buildDotNetGeoJSONLayerElevationInfoGenerated(jsObject, layerId, viewId);
}
