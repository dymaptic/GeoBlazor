
export async function buildJsMapImageLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMapImageLayerLayerviewDestroyEventGenerated } = await import('./mapImageLayerLayerviewDestroyEvent.gb');
    return await buildJsMapImageLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMapImageLayerLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let { buildDotNetMapImageLayerLayerviewDestroyEventGenerated } = await import('./mapImageLayerLayerviewDestroyEvent.gb');
    return await buildDotNetMapImageLayerLayerviewDestroyEventGenerated(jsObject);
}
