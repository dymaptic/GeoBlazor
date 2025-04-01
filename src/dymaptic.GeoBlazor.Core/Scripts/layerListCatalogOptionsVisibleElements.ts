
export async function buildJsLayerListCatalogOptionsVisibleElements(dotNetObject: any): Promise<any> {
    let { buildJsLayerListCatalogOptionsVisibleElementsGenerated } = await import('./layerListCatalogOptionsVisibleElements.gb');
    return await buildJsLayerListCatalogOptionsVisibleElementsGenerated(dotNetObject);
}     

export async function buildDotNetLayerListCatalogOptionsVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetLayerListCatalogOptionsVisibleElementsGenerated } = await import('./layerListCatalogOptionsVisibleElements.gb');
    return await buildDotNetLayerListCatalogOptionsVisibleElementsGenerated(jsObject);
}
