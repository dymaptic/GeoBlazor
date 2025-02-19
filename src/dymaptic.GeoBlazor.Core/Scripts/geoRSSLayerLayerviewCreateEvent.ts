export async function buildJsGeoRSSLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeoRSSLayerLayerviewCreateEventGenerated } = await import('./geoRSSLayerLayerviewCreateEvent.gb');
    return await buildJsGeoRSSLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetGeoRSSLayerLayerviewCreateEvent(jsObject: any): Promise<any> {
    let { buildDotNetGeoRSSLayerLayerviewCreateEventGenerated } = await import('./geoRSSLayerLayerviewCreateEvent.gb');
    return await buildDotNetGeoRSSLayerLayerviewCreateEventGenerated(jsObject);
}
