export async function buildJsTileLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTileLayerLayerviewDestroyEventGenerated} = await import('./tileLayerLayerviewDestroyEvent.gb');
    return await buildJsTileLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTileLayerLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let {buildDotNetTileLayerLayerviewDestroyEventGenerated} = await import('./tileLayerLayerviewDestroyEvent.gb');
    return await buildDotNetTileLayerLayerviewDestroyEventGenerated(jsObject);
}
