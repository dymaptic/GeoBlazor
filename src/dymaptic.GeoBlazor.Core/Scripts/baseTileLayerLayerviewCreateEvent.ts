export async function buildJsBaseTileLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBaseTileLayerLayerviewCreateEventGenerated} = await import('./baseTileLayerLayerviewCreateEvent.gb');
    return await buildJsBaseTileLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBaseTileLayerLayerviewCreateEvent(jsObject: any): Promise<any> {
    let {buildDotNetBaseTileLayerLayerviewCreateEventGenerated} = await import('./baseTileLayerLayerviewCreateEvent.gb');
    return await buildDotNetBaseTileLayerLayerviewCreateEventGenerated(jsObject);
}
