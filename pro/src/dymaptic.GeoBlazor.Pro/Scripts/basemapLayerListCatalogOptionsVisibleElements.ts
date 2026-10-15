
export async function buildJsBasemapLayerListCatalogOptionsVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBasemapLayerListCatalogOptionsVisibleElementsGenerated } = await import('./basemapLayerListCatalogOptionsVisibleElements.gb');
    return await buildJsBasemapLayerListCatalogOptionsVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBasemapLayerListCatalogOptionsVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetBasemapLayerListCatalogOptionsVisibleElementsGenerated } = await import('./basemapLayerListCatalogOptionsVisibleElements.gb');
    return await buildDotNetBasemapLayerListCatalogOptionsVisibleElementsGenerated(jsObject, viewId);
}
