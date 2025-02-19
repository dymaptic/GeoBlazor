export async function buildJsWFSLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWFSLayerLayerviewDestroyEventGenerated } = await import('./wFSLayerLayerviewDestroyEvent.gb');
    return await buildJsWFSLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetWFSLayerLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let { buildDotNetWFSLayerLayerviewDestroyEventGenerated } = await import('./wFSLayerLayerviewDestroyEvent.gb');
    return await buildDotNetWFSLayerLayerviewDestroyEventGenerated(jsObject);
}
