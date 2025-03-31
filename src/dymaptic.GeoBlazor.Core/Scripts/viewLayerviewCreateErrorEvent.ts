export async function buildJsViewLayerviewCreateErrorEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsViewLayerviewCreateErrorEventGenerated} = await import('./viewLayerviewCreateErrorEvent.gb');
    return await buildJsViewLayerviewCreateErrorEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetViewLayerviewCreateErrorEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetViewLayerviewCreateErrorEventGenerated} = await import('./viewLayerviewCreateErrorEvent.gb');
    return await buildDotNetViewLayerviewCreateErrorEventGenerated(jsObject, layerId, viewId);
}
