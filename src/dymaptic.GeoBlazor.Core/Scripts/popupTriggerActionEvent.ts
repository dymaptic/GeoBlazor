
export async function buildJsPopupTriggerActionEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPopupTriggerActionEventGenerated } = await import('./popupTriggerActionEvent.gb');
    return await buildJsPopupTriggerActionEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPopupTriggerActionEvent(jsObject: any): Promise<any> {
    let { buildDotNetPopupTriggerActionEventGenerated } = await import('./popupTriggerActionEvent.gb');
    return await buildDotNetPopupTriggerActionEventGenerated(jsObject);
}
