
export async function buildJsCatalogLayerListViewModelTriggerActionEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCatalogLayerListViewModelTriggerActionEventGenerated } = await import('./catalogLayerListViewModelTriggerActionEvent.gb');
    return await buildJsCatalogLayerListViewModelTriggerActionEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCatalogLayerListViewModelTriggerActionEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCatalogLayerListViewModelTriggerActionEventGenerated } = await import('./catalogLayerListViewModelTriggerActionEvent.gb');
    return await buildDotNetCatalogLayerListViewModelTriggerActionEventGenerated(jsObject, layerId, viewId);
}
