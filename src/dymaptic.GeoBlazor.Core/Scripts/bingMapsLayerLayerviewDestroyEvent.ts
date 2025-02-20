export async function buildJsBingMapsLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBingMapsLayerLayerviewDestroyEventGenerated} = await import('./bingMapsLayerLayerviewDestroyEvent.gb');
    return await buildJsBingMapsLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBingMapsLayerLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let {buildDotNetBingMapsLayerLayerviewDestroyEventGenerated} = await import('./bingMapsLayerLayerviewDestroyEvent.gb');
    return await buildDotNetBingMapsLayerLayerviewDestroyEventGenerated(jsObject);
}
