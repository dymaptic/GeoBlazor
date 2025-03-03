
export async function buildJsLayerListCatalogOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerListCatalogOptionsGenerated } = await import('./layerListCatalogOptions.gb');
    return await buildJsLayerListCatalogOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerListCatalogOptions(jsObject: any): Promise<any> {
    let { buildDotNetLayerListCatalogOptionsGenerated } = await import('./layerListCatalogOptions.gb');
    return await buildDotNetLayerListCatalogOptionsGenerated(jsObject);
}
