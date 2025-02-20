export async function buildJsBasemapLayerListTriggerActionEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBasemapLayerListTriggerActionEventGenerated} = await import('./basemapLayerListTriggerActionEvent.gb');
    return await buildJsBasemapLayerListTriggerActionEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBasemapLayerListTriggerActionEvent(jsObject: any): Promise<any> {
    let {buildDotNetBasemapLayerListTriggerActionEventGenerated} = await import('./basemapLayerListTriggerActionEvent.gb');
    return await buildDotNetBasemapLayerListTriggerActionEventGenerated(jsObject);
}
