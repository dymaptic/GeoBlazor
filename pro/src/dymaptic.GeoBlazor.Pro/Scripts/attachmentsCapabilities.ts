
export async function buildJsAttachmentsCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttachmentsCapabilitiesGenerated } = await import('./attachmentsCapabilities.gb');
    return await buildJsAttachmentsCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttachmentsCapabilities(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetAttachmentsCapabilitiesGenerated } = await import('./attachmentsCapabilities.gb');
    return await buildDotNetAttachmentsCapabilitiesGenerated(jsObject, viewId);
}
