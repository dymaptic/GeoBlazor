
export async function buildJsLayerListCatalogOptionsVisibleElements(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsLayerListCatalogOptionsVisibleElementsGenerated } = await import('./layerListCatalogOptionsVisibleElements.gb');
    return await buildJsLayerListCatalogOptionsVisibleElementsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetLayerListCatalogOptionsVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLayerListCatalogOptionsVisibleElementsGenerated } = await import('./layerListCatalogOptionsVisibleElements.gb');
    return await buildDotNetLayerListCatalogOptionsVisibleElementsGenerated(jsObject, viewId);
}
