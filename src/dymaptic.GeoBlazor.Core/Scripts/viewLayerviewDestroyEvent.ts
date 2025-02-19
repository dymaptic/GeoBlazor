
export async function buildJsViewLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewLayerviewDestroyEventGenerated } = await import('./viewLayerviewDestroyEvent.gb');
    return await buildJsViewLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let { buildDotNetViewLayerviewDestroyEventGenerated } = await import('./viewLayerviewDestroyEvent.gb');
    return await buildDotNetViewLayerviewDestroyEventGenerated(jsObject);
}
