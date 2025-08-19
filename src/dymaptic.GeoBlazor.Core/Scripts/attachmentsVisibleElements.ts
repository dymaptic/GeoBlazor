
export async function buildJsAttachmentsVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttachmentsVisibleElementsGenerated } = await import('./attachmentsVisibleElements.gb');
    return await buildJsAttachmentsVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttachmentsVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetAttachmentsVisibleElementsGenerated } = await import('./attachmentsVisibleElements.gb');
    return await buildDotNetAttachmentsVisibleElementsGenerated(jsObject, viewId);
}
