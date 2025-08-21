
export async function buildJsGeoJSONLayerElevationInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsGeoJSONLayerElevationInfoGenerated } = await import('./geoJSONLayerElevationInfo.gb');
    return await buildJsGeoJSONLayerElevationInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetGeoJSONLayerElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetGeoJSONLayerElevationInfoGenerated } = await import('./geoJSONLayerElevationInfo.gb');
    return await buildDotNetGeoJSONLayerElevationInfoGenerated(jsObject, viewId);
}
