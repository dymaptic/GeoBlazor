export async function buildJsGeoJSONLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGeoJSONLayerLayerviewDestroyEventGenerated} = await import('./geoJSONLayerLayerviewDestroyEvent.gb');
    return await buildJsGeoJSONLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGeoJSONLayerLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let {buildDotNetGeoJSONLayerLayerviewDestroyEventGenerated} = await import('./geoJSONLayerLayerviewDestroyEvent.gb');
    return await buildDotNetGeoJSONLayerLayerviewDestroyEventGenerated(jsObject);
}
