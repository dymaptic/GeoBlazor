
export async function buildJsCatalogLayerListVisibleElements(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsCatalogLayerListVisibleElementsGenerated } = await import('./catalogLayerListVisibleElements.gb');
    return await buildJsCatalogLayerListVisibleElementsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetCatalogLayerListVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetCatalogLayerListVisibleElementsGenerated } = await import('./catalogLayerListVisibleElements.gb');
    return await buildDotNetCatalogLayerListVisibleElementsGenerated(jsObject, viewId);
}
