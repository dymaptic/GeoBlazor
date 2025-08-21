
export async function buildJsVectorTileLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVectorTileLayerLayerviewDestroyEventGenerated } = await import('./vectorTileLayerLayerviewDestroyEvent.gb');
    return await buildJsVectorTileLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVectorTileLayerLayerviewDestroyEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVectorTileLayerLayerviewDestroyEventGenerated } = await import('./vectorTileLayerLayerviewDestroyEvent.gb');
    return await buildDotNetVectorTileLayerLayerviewDestroyEventGenerated(jsObject, viewId);
}
