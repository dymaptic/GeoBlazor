export async function buildJsSubtypeGroupLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSubtypeGroupLayerLayerviewDestroyEventGenerated} = await import('./subtypeGroupLayerLayerviewDestroyEvent.gb');
    return await buildJsSubtypeGroupLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSubtypeGroupLayerLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let {buildDotNetSubtypeGroupLayerLayerviewDestroyEventGenerated} = await import('./subtypeGroupLayerLayerviewDestroyEvent.gb');
    return await buildDotNetSubtypeGroupLayerLayerviewDestroyEventGenerated(jsObject);
}
