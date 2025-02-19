
export async function buildJsLayerListTriggerActionEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerListTriggerActionEventGenerated } = await import('./layerListTriggerActionEvent.gb');
    return await buildJsLayerListTriggerActionEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerListTriggerActionEvent(jsObject: any): Promise<any> {
    let { buildDotNetLayerListTriggerActionEventGenerated } = await import('./layerListTriggerActionEvent.gb');
    return await buildDotNetLayerListTriggerActionEventGenerated(jsObject);
}
