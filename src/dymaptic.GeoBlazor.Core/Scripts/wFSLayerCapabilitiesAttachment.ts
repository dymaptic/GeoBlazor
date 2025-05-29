
export async function buildJsWFSLayerCapabilitiesAttachment(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWFSLayerCapabilitiesAttachmentGenerated } = await import('./wFSLayerCapabilitiesAttachment.gb');
    return await buildJsWFSLayerCapabilitiesAttachmentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWFSLayerCapabilitiesAttachment(jsObject: any): Promise<any> {
    let { buildDotNetWFSLayerCapabilitiesAttachmentGenerated } = await import('./wFSLayerCapabilitiesAttachment.gb');
    return await buildDotNetWFSLayerCapabilitiesAttachmentGenerated(jsObject);
}
