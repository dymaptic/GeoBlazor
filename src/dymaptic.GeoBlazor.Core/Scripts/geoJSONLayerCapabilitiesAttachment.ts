
export async function buildJsGeoJSONLayerCapabilitiesAttachment(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeoJSONLayerCapabilitiesAttachmentGenerated } = await import('./geoJSONLayerCapabilitiesAttachment.gb');
    return await buildJsGeoJSONLayerCapabilitiesAttachmentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeoJSONLayerCapabilitiesAttachment(jsObject: any): Promise<any> {
    let { buildDotNetGeoJSONLayerCapabilitiesAttachmentGenerated } = await import('./geoJSONLayerCapabilitiesAttachment.gb');
    return await buildDotNetGeoJSONLayerCapabilitiesAttachmentGenerated(jsObject);
}
