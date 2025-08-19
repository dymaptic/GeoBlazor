export async function buildJsWMSLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWMSLayerLayerviewCreateEventGenerated} = await import('./wMSLayerLayerviewCreateEvent.gb');
    return await buildJsWMSLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWMSLayerLayerviewCreateEvent(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetWMSLayerLayerviewCreateEventGenerated} = await import('./wMSLayerLayerviewCreateEvent.gb');
    return await buildDotNetWMSLayerLayerviewCreateEventGenerated(jsObject, viewId);
}
