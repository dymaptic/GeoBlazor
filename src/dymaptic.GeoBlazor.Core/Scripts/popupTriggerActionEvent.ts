
export async function buildJsPopupTriggerActionEvent(dotNetObject: any): Promise<any> {
    let { buildJsPopupTriggerActionEventGenerated } = await import('./popupTriggerActionEvent.gb');
    return await buildJsPopupTriggerActionEventGenerated(dotNetObject);
}     

export async function buildDotNetPopupTriggerActionEvent(jsObject: any): Promise<any> {
    let { buildDotNetPopupTriggerActionEventGenerated } = await import('./popupTriggerActionEvent.gb');
    return await buildDotNetPopupTriggerActionEventGenerated(jsObject);
}
