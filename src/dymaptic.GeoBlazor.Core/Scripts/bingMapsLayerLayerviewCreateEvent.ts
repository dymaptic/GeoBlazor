export async function buildJsBingMapsLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBingMapsLayerLayerviewCreateEventGenerated} = await import('./bingMapsLayerLayerviewCreateEvent.gb');
    return await buildJsBingMapsLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBingMapsLayerLayerviewCreateEvent(jsObject: any): Promise<any> {
    let {buildDotNetBingMapsLayerLayerviewCreateEventGenerated} = await import('./bingMapsLayerLayerviewCreateEvent.gb');
    return await buildDotNetBingMapsLayerLayerviewCreateEventGenerated(jsObject);
}
