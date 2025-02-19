
export async function buildJsLayerListViewModelTriggerActionEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerListViewModelTriggerActionEventGenerated } = await import('./layerListViewModelTriggerActionEvent.gb');
    return await buildJsLayerListViewModelTriggerActionEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerListViewModelTriggerActionEvent(jsObject: any): Promise<any> {
    let { buildDotNetLayerListViewModelTriggerActionEventGenerated } = await import('./layerListViewModelTriggerActionEvent.gb');
    return await buildDotNetLayerListViewModelTriggerActionEventGenerated(jsObject);
}
