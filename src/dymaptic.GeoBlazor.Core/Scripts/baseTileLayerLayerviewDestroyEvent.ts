export async function buildJsBaseTileLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBaseTileLayerLayerviewDestroyEventGenerated} = await import('./baseTileLayerLayerviewDestroyEvent.gb');
    return await buildJsBaseTileLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBaseTileLayerLayerviewDestroyEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetBaseTileLayerLayerviewDestroyEventGenerated} = await import('./baseTileLayerLayerviewDestroyEvent.gb');
    return await buildDotNetBaseTileLayerLayerviewDestroyEventGenerated(jsObject, layerId, viewId);
}
