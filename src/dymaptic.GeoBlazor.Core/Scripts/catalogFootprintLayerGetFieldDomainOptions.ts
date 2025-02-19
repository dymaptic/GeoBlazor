
export async function buildJsCatalogFootprintLayerGetFieldDomainOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCatalogFootprintLayerGetFieldDomainOptionsGenerated } = await import('./catalogFootprintLayerGetFieldDomainOptions.gb');
    return await buildJsCatalogFootprintLayerGetFieldDomainOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCatalogFootprintLayerGetFieldDomainOptions(jsObject: any): Promise<any> {
    let { buildDotNetCatalogFootprintLayerGetFieldDomainOptionsGenerated } = await import('./catalogFootprintLayerGetFieldDomainOptions.gb');
    return await buildDotNetCatalogFootprintLayerGetFieldDomainOptionsGenerated(jsObject);
}
