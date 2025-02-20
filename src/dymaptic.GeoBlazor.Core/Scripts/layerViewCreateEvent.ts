export async function buildJsLayerViewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLayerViewCreateEventGenerated} = await import('./layerViewCreateEvent.gb');
    return await buildJsLayerViewCreateEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLayerViewCreateEvent(jsObject: any): Promise<any> {
    let {buildDotNetLayerViewCreateEventGenerated} = await import('./layerViewCreateEvent.gb');
    return await buildDotNetLayerViewCreateEventGenerated(jsObject);
}
