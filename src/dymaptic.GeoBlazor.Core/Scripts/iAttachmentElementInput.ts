
export async function buildJsIAttachmentElementInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIAttachmentElementInputGenerated } = await import('./iAttachmentElementInput.gb');
    return await buildJsIAttachmentElementInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIAttachmentElementInput(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIAttachmentElementInputGenerated } = await import('./iAttachmentElementInput.gb');
    return await buildDotNetIAttachmentElementInputGenerated(jsObject, viewId);
}
