
export async function buildJsCatalogFootprintLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsCatalogFootprintLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./catalogFootprintLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsCatalogFootprintLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetCatalogFootprintLayerElevationInfoFeatureExpressionInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetCatalogFootprintLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./catalogFootprintLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetCatalogFootprintLayerElevationInfoFeatureExpressionInfoGenerated(jsObject, viewId);
}
