
export async function buildJsOGCFeatureLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOGCFeatureLayerLayerviewDestroyEventGenerated } = await import('./oGCFeatureLayerLayerviewDestroyEvent.gb');
    return await buildJsOGCFeatureLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOGCFeatureLayerLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let { buildDotNetOGCFeatureLayerLayerviewDestroyEventGenerated } = await import('./oGCFeatureLayerLayerviewDestroyEvent.gb');
    return await buildDotNetOGCFeatureLayerLayerviewDestroyEventGenerated(jsObject);
}
