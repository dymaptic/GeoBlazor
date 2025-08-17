
export async function buildJsAttachmentsCapabilitiesOperations(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttachmentsCapabilitiesOperationsGenerated } = await import('./attachmentsCapabilitiesOperations.gb');
    return await buildJsAttachmentsCapabilitiesOperationsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttachmentsCapabilitiesOperations(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetAttachmentsCapabilitiesOperationsGenerated } = await import('./attachmentsCapabilitiesOperations.gb');
    return await buildDotNetAttachmentsCapabilitiesOperationsGenerated(jsObject, viewId);
}
