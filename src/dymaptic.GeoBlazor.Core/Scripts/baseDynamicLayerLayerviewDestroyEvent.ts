export async function buildJsBaseDynamicLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBaseDynamicLayerLayerviewDestroyEventGenerated } = await import('./baseDynamicLayerLayerviewDestroyEvent.gb');
    return await buildJsBaseDynamicLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetBaseDynamicLayerLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let { buildDotNetBaseDynamicLayerLayerviewDestroyEventGenerated } = await import('./baseDynamicLayerLayerviewDestroyEvent.gb');
    return await buildDotNetBaseDynamicLayerLayerviewDestroyEventGenerated(jsObject);
}
