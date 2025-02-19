export async function buildJsWFSLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWFSLayerLayerviewCreateEventGenerated } = await import('./wFSLayerLayerviewCreateEvent.gb');
    return await buildJsWFSLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetWFSLayerLayerviewCreateEvent(jsObject: any): Promise<any> {
    let { buildDotNetWFSLayerLayerviewCreateEventGenerated } = await import('./wFSLayerLayerviewCreateEvent.gb');
    return await buildDotNetWFSLayerLayerviewCreateEventGenerated(jsObject);
}
