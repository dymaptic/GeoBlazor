
export async function buildJsAttachmentsColumnTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttachmentsColumnTemplateGenerated } = await import('./attachmentsColumnTemplate.gb');
    return await buildJsAttachmentsColumnTemplateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttachmentsColumnTemplate(jsObject: any): Promise<any> {
    let { buildDotNetAttachmentsColumnTemplateGenerated } = await import('./attachmentsColumnTemplate.gb');
    return await buildDotNetAttachmentsColumnTemplateGenerated(jsObject);
}
