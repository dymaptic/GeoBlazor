export async function buildJsCatalogLayerLayerviewCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCatalogLayerLayerviewCreateEventGenerated} = await import('./catalogLayerLayerviewCreateEvent.gb');
    return await buildJsCatalogLayerLayerviewCreateEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCatalogLayerLayerviewCreateEvent(jsObject: any): Promise<any> {
    let {buildDotNetCatalogLayerLayerviewCreateEventGenerated} = await import('./catalogLayerLayerviewCreateEvent.gb');
    return await buildDotNetCatalogLayerLayerviewCreateEventGenerated(jsObject);
}
