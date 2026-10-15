
export async function buildJsTableListTriggerActionEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTableListTriggerActionEventGenerated } = await import('./tableListTriggerActionEvent.gb');
    return await buildJsTableListTriggerActionEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTableListTriggerActionEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTableListTriggerActionEventGenerated } = await import('./tableListTriggerActionEvent.gb');
    return await buildDotNetTableListTriggerActionEventGenerated(jsObject, layerId, viewId);
}
