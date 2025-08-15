export async function buildJsMapImageLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMapImageLayerLayerviewCreateEventGenerated} = await import('./mapImageLayerLayerviewCreateEvent.gb');
    return await buildJsMapImageLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMapImageLayerLayerviewCreateEvent(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetMapImageLayerLayerviewCreateEventGenerated} = await import('./mapImageLayerLayerviewCreateEvent.gb');
    return await buildDotNetMapImageLayerLayerviewCreateEventGenerated(jsObject, viewId);
}
