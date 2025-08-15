
export async function buildJsIntegratedMesh3DTilesLayerElevationInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIntegratedMesh3DTilesLayerElevationInfoGenerated } = await import('./integratedMesh3DTilesLayerElevationInfo.gb');
    return await buildJsIntegratedMesh3DTilesLayerElevationInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIntegratedMesh3DTilesLayerElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIntegratedMesh3DTilesLayerElevationInfoGenerated } = await import('./integratedMesh3DTilesLayerElevationInfo.gb');
    return await buildDotNetIntegratedMesh3DTilesLayerElevationInfoGenerated(jsObject, viewId);
}
