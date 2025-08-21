
export async function buildJsVectorTileLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVectorTileLayerLayerviewCreateEventGenerated } = await import('./vectorTileLayerLayerviewCreateEvent.gb');
    return await buildJsVectorTileLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVectorTileLayerLayerviewCreateEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVectorTileLayerLayerviewCreateEventGenerated } = await import('./vectorTileLayerLayerviewCreateEvent.gb');
    return await buildDotNetVectorTileLayerLayerviewCreateEventGenerated(jsObject, viewId);
}
