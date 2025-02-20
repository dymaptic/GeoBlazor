export async function buildJsCatalogLayerLayerviewDestroyEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCatalogLayerLayerviewDestroyEventGenerated} = await import('./catalogLayerLayerviewDestroyEvent.gb');
    return await buildJsCatalogLayerLayerviewDestroyEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCatalogLayerLayerviewDestroyEvent(jsObject: any): Promise<any> {
    let {buildDotNetCatalogLayerLayerviewDestroyEventGenerated} = await import('./catalogLayerLayerviewDestroyEvent.gb');
    return await buildDotNetCatalogLayerLayerviewDestroyEventGenerated(jsObject);
}
