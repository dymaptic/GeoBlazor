
export async function buildJsCSVLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCSVLayerLayerviewDestroyEventGenerated } = await import('./cSVLayerLayerviewDestroyEvent.gb');
    return await buildJsCSVLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCSVLayerLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let { buildDotNetCSVLayerLayerviewDestroyEventGenerated } = await import('./cSVLayerLayerviewDestroyEvent.gb');
    return await buildDotNetCSVLayerLayerviewDestroyEventGenerated(jsObject);
}
