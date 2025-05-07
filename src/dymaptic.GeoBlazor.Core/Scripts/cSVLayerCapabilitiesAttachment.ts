
export async function buildJsCSVLayerCapabilitiesAttachment(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCSVLayerCapabilitiesAttachmentGenerated } = await import('./cSVLayerCapabilitiesAttachment.gb');
    return await buildJsCSVLayerCapabilitiesAttachmentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCSVLayerCapabilitiesAttachment(jsObject: any): Promise<any> {
    let { buildDotNetCSVLayerCapabilitiesAttachmentGenerated } = await import('./cSVLayerCapabilitiesAttachment.gb');
    return await buildDotNetCSVLayerCapabilitiesAttachmentGenerated(jsObject);
}
