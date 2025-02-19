
export async function buildJsViewLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewLayerviewCreateEventGenerated } = await import('./viewLayerviewCreateEvent.gb');
    return await buildJsViewLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewLayerviewCreateEvent(jsObject: any): Promise<any> {
    let { buildDotNetViewLayerviewCreateEventGenerated } = await import('./viewLayerviewCreateEvent.gb');
    return await buildDotNetViewLayerviewCreateEventGenerated(jsObject);
}
