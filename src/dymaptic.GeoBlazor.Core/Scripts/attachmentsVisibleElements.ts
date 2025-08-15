
export async function buildJsAttachmentsVisibleElements(dotNetObject: any): Promise<any> {
    let { buildJsAttachmentsVisibleElementsGenerated } = await import('./attachmentsVisibleElements.gb');
    return await buildJsAttachmentsVisibleElementsGenerated(dotNetObject);
}     

export async function buildDotNetAttachmentsVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetAttachmentsVisibleElementsGenerated } = await import('./attachmentsVisibleElements.gb');
    return await buildDotNetAttachmentsVisibleElementsGenerated(jsObject);
}
