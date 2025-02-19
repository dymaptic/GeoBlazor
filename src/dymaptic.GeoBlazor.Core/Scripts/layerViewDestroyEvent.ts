
export async function buildJsLayerViewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerViewDestroyEventGenerated } = await import('./layerViewDestroyEvent.gb');
    return await buildJsLayerViewDestroyEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerViewDestroyEvent(jsObject: any): Promise<any> {
    let { buildDotNetLayerViewDestroyEventGenerated } = await import('./layerViewDestroyEvent.gb');
    return await buildDotNetLayerViewDestroyEventGenerated(jsObject);
}
