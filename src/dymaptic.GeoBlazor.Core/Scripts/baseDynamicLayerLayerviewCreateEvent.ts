export async function buildJsBaseDynamicLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBaseDynamicLayerLayerviewCreateEventGenerated } = await import('./baseDynamicLayerLayerviewCreateEvent.gb');
    return await buildJsBaseDynamicLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetBaseDynamicLayerLayerviewCreateEvent(jsObject: any): Promise<any> {
    let { buildDotNetBaseDynamicLayerLayerviewCreateEventGenerated } = await import('./baseDynamicLayerLayerviewCreateEvent.gb');
    return await buildDotNetBaseDynamicLayerLayerviewCreateEventGenerated(jsObject);
}
