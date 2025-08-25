export async function buildJsWebTileLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWebTileLayerLayerviewCreateEventGenerated} = await import('./webTileLayerLayerviewCreateEvent.gb');
    return await buildJsWebTileLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWebTileLayerLayerviewCreateEvent(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetWebTileLayerLayerviewCreateEventGenerated} = await import('./webTileLayerLayerviewCreateEvent.gb');
    return await buildDotNetWebTileLayerLayerviewCreateEventGenerated(jsObject, viewId);
}
