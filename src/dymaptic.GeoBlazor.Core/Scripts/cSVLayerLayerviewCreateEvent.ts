export async function buildJsCSVLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCSVLayerLayerviewCreateEventGenerated} = await import('./cSVLayerLayerviewCreateEvent.gb');
    return await buildJsCSVLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCSVLayerLayerviewCreateEvent(jsObject: any): Promise<any> {
    let {buildDotNetCSVLayerLayerviewCreateEventGenerated} = await import('./cSVLayerLayerviewCreateEvent.gb');
    return await buildDotNetCSVLayerLayerviewCreateEventGenerated(jsObject);
}
