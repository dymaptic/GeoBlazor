
export async function buildJsOpenStreetMapLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOpenStreetMapLayerLayerviewCreateEventGenerated } = await import('./openStreetMapLayerLayerviewCreateEvent.gb');
    return await buildJsOpenStreetMapLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOpenStreetMapLayerLayerviewCreateEvent(jsObject: any): Promise<any> {
    let { buildDotNetOpenStreetMapLayerLayerviewCreateEventGenerated } = await import('./openStreetMapLayerLayerviewCreateEvent.gb');
    return await buildDotNetOpenStreetMapLayerLayerviewCreateEventGenerated(jsObject);
}
