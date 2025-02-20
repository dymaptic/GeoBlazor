export async function buildJsOGCFeatureLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsOGCFeatureLayerLayerviewCreateEventGenerated} = await import('./oGCFeatureLayerLayerviewCreateEvent.gb');
    return await buildJsOGCFeatureLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetOGCFeatureLayerLayerviewCreateEvent(jsObject: any): Promise<any> {
    let {buildDotNetOGCFeatureLayerLayerviewCreateEventGenerated} = await import('./oGCFeatureLayerLayerviewCreateEvent.gb');
    return await buildDotNetOGCFeatureLayerLayerviewCreateEventGenerated(jsObject);
}
