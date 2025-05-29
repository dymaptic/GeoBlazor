
export async function buildJsGeoJSONLayerCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeoJSONLayerCapabilitiesGenerated } = await import('./geoJSONLayerCapabilities.gb');
    return await buildJsGeoJSONLayerCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeoJSONLayerCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetGeoJSONLayerCapabilitiesGenerated } = await import('./geoJSONLayerCapabilities.gb');
    return await buildDotNetGeoJSONLayerCapabilitiesGenerated(jsObject);
}
