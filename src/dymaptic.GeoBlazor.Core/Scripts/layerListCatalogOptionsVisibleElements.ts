
export async function buildJsLayerListCatalogOptionsVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerListCatalogOptionsVisibleElementsGenerated } = await import('./layerListCatalogOptionsVisibleElements.gb');
    return await buildJsLayerListCatalogOptionsVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerListCatalogOptionsVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetLayerListCatalogOptionsVisibleElementsGenerated } = await import('./layerListCatalogOptionsVisibleElements.gb');
    return await buildDotNetLayerListCatalogOptionsVisibleElementsGenerated(jsObject);
}
