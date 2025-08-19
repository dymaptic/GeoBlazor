export async function buildJsWMSLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWMSLayerLayerviewDestroyEventGenerated} = await import('./wMSLayerLayerviewDestroyEvent.gb');
    return await buildJsWMSLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWMSLayerLayerviewDestroyEvent(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetWMSLayerLayerviewDestroyEventGenerated} = await import('./wMSLayerLayerviewDestroyEvent.gb');
    return await buildDotNetWMSLayerLayerviewDestroyEventGenerated(jsObject, viewId);
}
