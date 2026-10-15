
export async function buildJsAttributeTableAttachmentElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttributeTableAttachmentElementGenerated } = await import('./attributeTableAttachmentElement.gb');
    return await buildJsAttributeTableAttachmentElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttributeTableAttachmentElement(jsObject: any): Promise<any> {
    let { buildDotNetAttributeTableAttachmentElementGenerated } = await import('./attributeTableAttachmentElement.gb');
    return await buildDotNetAttributeTableAttachmentElementGenerated(jsObject);
}
