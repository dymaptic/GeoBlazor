
export async function buildJsCatalogDynamicGroupLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCatalogDynamicGroupLayerViewGenerated } = await import('./catalogDynamicGroupLayerView.gb');
    return await buildJsCatalogDynamicGroupLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCatalogDynamicGroupLayerView(jsObject: any): Promise<any> {
    let { buildDotNetCatalogDynamicGroupLayerViewGenerated } = await import('./catalogDynamicGroupLayerView.gb');
    return await buildDotNetCatalogDynamicGroupLayerViewGenerated(jsObject);
}
