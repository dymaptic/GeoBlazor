
export async function buildJsPopupTriggerActionEvent(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsPopupTriggerActionEventGenerated } = await import('./popupTriggerActionEvent.gb');
    return await buildJsPopupTriggerActionEventGenerated(dotNetObject, viewId);
}     

export async function buildDotNetPopupTriggerActionEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPopupTriggerActionEventGenerated } = await import('./popupTriggerActionEvent.gb');
    return await buildDotNetPopupTriggerActionEventGenerated(jsObject, viewId);
}
