export async function buildJsTileLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTileLayerLayerviewCreateEventGenerated} = await import('./tileLayerLayerviewCreateEvent.gb');
    return await buildJsTileLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTileLayerLayerviewCreateEvent(jsObject: any): Promise<any> {
    let {buildDotNetTileLayerLayerviewCreateEventGenerated} = await import('./tileLayerLayerviewCreateEvent.gb');
    return await buildDotNetTileLayerLayerviewCreateEventGenerated(jsObject);
}
