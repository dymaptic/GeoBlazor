export async function buildJsGeoRSSLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGeoRSSLayerLayerviewDestroyEventGenerated} = await import('./geoRSSLayerLayerviewDestroyEvent.gb');
    return await buildJsGeoRSSLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGeoRSSLayerLayerviewDestroyEvent(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetGeoRSSLayerLayerviewDestroyEventGenerated} = await import('./geoRSSLayerLayerviewDestroyEvent.gb');
    return await buildDotNetGeoRSSLayerLayerviewDestroyEventGenerated(jsObject, viewId);
}
