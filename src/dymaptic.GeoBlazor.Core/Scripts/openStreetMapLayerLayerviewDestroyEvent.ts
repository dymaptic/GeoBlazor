export async function buildJsOpenStreetMapLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOpenStreetMapLayerLayerviewDestroyEventGenerated } = await import('./openStreetMapLayerLayerviewDestroyEvent.gb');
    return await buildJsOpenStreetMapLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetOpenStreetMapLayerLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let { buildDotNetOpenStreetMapLayerLayerviewDestroyEventGenerated } = await import('./openStreetMapLayerLayerviewDestroyEvent.gb');
    return await buildDotNetOpenStreetMapLayerLayerviewDestroyEventGenerated(jsObject);
}
