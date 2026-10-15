
export async function buildJsCatalogFootprintLayerElevationInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsCatalogFootprintLayerElevationInfoGenerated } = await import('./catalogFootprintLayerElevationInfo.gb');
    return await buildJsCatalogFootprintLayerElevationInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetCatalogFootprintLayerElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetCatalogFootprintLayerElevationInfoGenerated } = await import('./catalogFootprintLayerElevationInfo.gb');
    return await buildDotNetCatalogFootprintLayerElevationInfoGenerated(jsObject, viewId);
}
