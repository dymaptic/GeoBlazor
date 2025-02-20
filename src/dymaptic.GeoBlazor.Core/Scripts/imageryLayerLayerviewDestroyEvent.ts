export async function buildJsImageryLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageryLayerLayerviewDestroyEventGenerated} = await import('./imageryLayerLayerviewDestroyEvent.gb');
    return await buildJsImageryLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageryLayerLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let {buildDotNetImageryLayerLayerviewDestroyEventGenerated} = await import('./imageryLayerLayerviewDestroyEvent.gb');
    return await buildDotNetImageryLayerLayerviewDestroyEventGenerated(jsObject);
}
