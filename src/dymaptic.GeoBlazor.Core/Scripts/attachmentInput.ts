
export async function buildJsAttachmentInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttachmentInputGenerated } = await import('./attachmentInput.gb');
    return await buildJsAttachmentInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttachmentInput(jsObject: any): Promise<any> {
    let { buildDotNetAttachmentInputGenerated } = await import('./attachmentInput.gb');
    return await buildDotNetAttachmentInputGenerated(jsObject);
}
