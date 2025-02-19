export async function buildJsPopupTemplateCreatorEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPopupTemplateCreatorEventGenerated } = await import('./popupTemplateCreatorEvent.gb');
    return await buildJsPopupTemplateCreatorEventGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPopupTemplateCreatorEvent(jsObject: any): Promise<any> {
    let { buildDotNetPopupTemplateCreatorEventGenerated } = await import('./popupTemplateCreatorEvent.gb');
    return await buildDotNetPopupTemplateCreatorEventGenerated(jsObject);
}
