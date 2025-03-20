
export async function buildJsLayerListCatalogOptions(dotNetObject: any): Promise<any> {
    let { buildJsLayerListCatalogOptionsGenerated } = await import('./layerListCatalogOptions.gb');
    return await buildJsLayerListCatalogOptionsGenerated(dotNetObject);
}     

export async function buildDotNetLayerListCatalogOptions(jsObject: any): Promise<any> {
    let { buildDotNetLayerListCatalogOptionsGenerated } = await import('./layerListCatalogOptions.gb');
    return await buildDotNetLayerListCatalogOptionsGenerated(jsObject);
}
