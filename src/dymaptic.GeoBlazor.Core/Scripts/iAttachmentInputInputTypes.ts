
export async function buildJsIAttachmentInputInputTypes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIAttachmentInputInputTypesGenerated } = await import('./iAttachmentInputInputTypes.gb');
    return await buildJsIAttachmentInputInputTypesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIAttachmentInputInputTypes(jsObject: any): Promise<any> {
    let { buildDotNetIAttachmentInputInputTypesGenerated } = await import('./iAttachmentInputInputTypes.gb');
    return await buildDotNetIAttachmentInputInputTypesGenerated(jsObject);
}
