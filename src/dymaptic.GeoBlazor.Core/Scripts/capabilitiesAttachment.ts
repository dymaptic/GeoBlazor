
export async function buildJsCapabilitiesAttachment(dotNetObject: any): Promise<any> {
    let { buildJsCapabilitiesAttachmentGenerated } = await import('./capabilitiesAttachment.gb');
    return await buildJsCapabilitiesAttachmentGenerated(dotNetObject);
}     

export async function buildDotNetCapabilitiesAttachment(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesAttachmentGenerated } = await import('./capabilitiesAttachment.gb');
    return await buildDotNetCapabilitiesAttachmentGenerated(jsObject);
}
