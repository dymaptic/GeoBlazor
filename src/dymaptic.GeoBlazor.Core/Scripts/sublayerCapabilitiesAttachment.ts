
export async function buildJsSublayerCapabilitiesAttachment(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSublayerCapabilitiesAttachmentGenerated } = await import('./sublayerCapabilitiesAttachment.gb');
    return await buildJsSublayerCapabilitiesAttachmentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSublayerCapabilitiesAttachment(jsObject: any): Promise<any> {
    let { buildDotNetSublayerCapabilitiesAttachmentGenerated } = await import('./sublayerCapabilitiesAttachment.gb');
    return await buildDotNetSublayerCapabilitiesAttachmentGenerated(jsObject);
}
