
export async function buildJsCatalogLayerListTriggerActionEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCatalogLayerListTriggerActionEventGenerated } = await import('./catalogLayerListTriggerActionEvent.gb');
    return await buildJsCatalogLayerListTriggerActionEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCatalogLayerListTriggerActionEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCatalogLayerListTriggerActionEventGenerated } = await import('./catalogLayerListTriggerActionEvent.gb');
    return await buildDotNetCatalogLayerListTriggerActionEventGenerated(jsObject, layerId, viewId);
}
