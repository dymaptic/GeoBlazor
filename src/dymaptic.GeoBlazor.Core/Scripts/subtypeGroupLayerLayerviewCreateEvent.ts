export async function buildJsSubtypeGroupLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSubtypeGroupLayerLayerviewCreateEventGenerated } = await import('./subtypeGroupLayerLayerviewCreateEvent.gb');
    return await buildJsSubtypeGroupLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSubtypeGroupLayerLayerviewCreateEvent(jsObject: any): Promise<any> {
    let { buildDotNetSubtypeGroupLayerLayerviewCreateEventGenerated } = await import('./subtypeGroupLayerLayerviewCreateEvent.gb');
    return await buildDotNetSubtypeGroupLayerLayerviewCreateEventGenerated(jsObject);
}
