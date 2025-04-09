
export async function buildJsAttachmentElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttachmentElementGenerated } = await import('./attachmentElement.gb');
    return await buildJsAttachmentElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttachmentElement(jsObject: any): Promise<any> {
    let { buildDotNetAttachmentElementGenerated } = await import('./attachmentElement.gb');
    return await buildDotNetAttachmentElementGenerated(jsObject);
}
