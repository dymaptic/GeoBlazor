
export async function buildJsIntegratedMesh3DTilesLayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIntegratedMesh3DTilesLayerElevationInfoGenerated } = await import('./integratedMesh3DTilesLayerElevationInfo.gb');
    return await buildJsIntegratedMesh3DTilesLayerElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIntegratedMesh3DTilesLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetIntegratedMesh3DTilesLayerElevationInfoGenerated } = await import('./integratedMesh3DTilesLayerElevationInfo.gb');
    return await buildDotNetIntegratedMesh3DTilesLayerElevationInfoGenerated(jsObject);
}
