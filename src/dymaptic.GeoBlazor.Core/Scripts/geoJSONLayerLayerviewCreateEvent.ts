export async function buildJsGeoJSONLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGeoJSONLayerLayerviewCreateEventGenerated} = await import('./geoJSONLayerLayerviewCreateEvent.gb');
    return await buildJsGeoJSONLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGeoJSONLayerLayerviewCreateEvent(jsObject: any): Promise<any> {
    let {buildDotNetGeoJSONLayerLayerviewCreateEventGenerated} = await import('./geoJSONLayerLayerviewCreateEvent.gb');
    return await buildDotNetGeoJSONLayerLayerviewCreateEventGenerated(jsObject);
}
