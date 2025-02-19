export async function buildJsWebTileLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebTileLayerLayerviewDestroyEventGenerated } = await import('./webTileLayerLayerviewDestroyEvent.gb');
    return await buildJsWebTileLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetWebTileLayerLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let { buildDotNetWebTileLayerLayerviewDestroyEventGenerated } = await import('./webTileLayerLayerviewDestroyEvent.gb');
    return await buildDotNetWebTileLayerLayerviewDestroyEventGenerated(jsObject);
}
