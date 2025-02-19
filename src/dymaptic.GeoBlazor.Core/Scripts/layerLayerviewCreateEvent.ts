export async function buildJsLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerLayerviewCreateEventGenerated } = await import('./layerLayerviewCreateEvent.gb');
    return await buildJsLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetLayerLayerviewCreateEvent(jsObject: any): Promise<any> {
    let { buildDotNetLayerLayerviewCreateEventGenerated } = await import('./layerLayerviewCreateEvent.gb');
    return await buildDotNetLayerLayerviewCreateEventGenerated(jsObject);
}
