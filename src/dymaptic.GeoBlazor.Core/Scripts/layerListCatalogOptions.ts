
export async function buildJsLayerListCatalogOptions(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsLayerListCatalogOptionsGenerated } = await import('./layerListCatalogOptions.gb');
    return await buildJsLayerListCatalogOptionsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetLayerListCatalogOptions(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLayerListCatalogOptionsGenerated } = await import('./layerListCatalogOptions.gb');
    return await buildDotNetLayerListCatalogOptionsGenerated(jsObject, viewId);
}
