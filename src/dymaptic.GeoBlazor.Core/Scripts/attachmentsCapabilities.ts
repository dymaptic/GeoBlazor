
export async function buildJsAttachmentsCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttachmentsCapabilitiesGenerated } = await import('./attachmentsCapabilities.gb');
    return await buildJsAttachmentsCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttachmentsCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetAttachmentsCapabilitiesGenerated } = await import('./attachmentsCapabilities.gb');
    return await buildDotNetAttachmentsCapabilitiesGenerated(jsObject);
}
