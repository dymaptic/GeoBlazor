
export async function buildJsLayerViewCreateErrorEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerViewCreateErrorEventGenerated } = await import('./layerViewCreateErrorEvent.gb');
    return await buildJsLayerViewCreateErrorEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerViewCreateErrorEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLayerViewCreateErrorEventGenerated } = await import('./layerViewCreateErrorEvent.gb');
    return await buildDotNetLayerViewCreateErrorEventGenerated(jsObject, layerId, viewId);
}
