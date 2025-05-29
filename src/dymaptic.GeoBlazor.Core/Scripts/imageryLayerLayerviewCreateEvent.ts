export async function buildJsImageryLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageryLayerLayerviewCreateEventGenerated} = await import('./imageryLayerLayerviewCreateEvent.gb');
    return await buildJsImageryLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageryLayerLayerviewCreateEvent(jsObject: any): Promise<any> {
    let {buildDotNetImageryLayerLayerviewCreateEventGenerated} = await import('./imageryLayerLayerviewCreateEvent.gb');
    return await buildDotNetImageryLayerLayerviewCreateEventGenerated(jsObject);
}
