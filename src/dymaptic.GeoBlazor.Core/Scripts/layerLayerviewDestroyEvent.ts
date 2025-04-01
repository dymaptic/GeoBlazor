export async function buildJsLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLayerLayerviewDestroyEventGenerated} = await import('./layerLayerviewDestroyEvent.gb');
    return await buildJsLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLayerLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let {buildDotNetLayerLayerviewDestroyEventGenerated} = await import('./layerLayerviewDestroyEvent.gb');
    return await buildDotNetLayerLayerviewDestroyEventGenerated(jsObject);
}
