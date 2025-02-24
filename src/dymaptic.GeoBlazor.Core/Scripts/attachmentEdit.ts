
export async function buildJsAttachmentEdit(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttachmentEditGenerated } = await import('./attachmentEdit.gb');
    return await buildJsAttachmentEditGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttachmentEdit(jsObject: any): Promise<any> {
    let { buildDotNetAttachmentEditGenerated } = await import('./attachmentEdit.gb');
    return await buildDotNetAttachmentEditGenerated(jsObject);
}
