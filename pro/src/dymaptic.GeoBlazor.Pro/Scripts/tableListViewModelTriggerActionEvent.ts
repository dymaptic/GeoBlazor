
export async function buildJsTableListViewModelTriggerActionEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTableListViewModelTriggerActionEventGenerated } = await import('./tableListViewModelTriggerActionEvent.gb');
    return await buildJsTableListViewModelTriggerActionEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTableListViewModelTriggerActionEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTableListViewModelTriggerActionEventGenerated } = await import('./tableListViewModelTriggerActionEvent.gb');
    return await buildDotNetTableListViewModelTriggerActionEventGenerated(jsObject, layerId, viewId);
}
