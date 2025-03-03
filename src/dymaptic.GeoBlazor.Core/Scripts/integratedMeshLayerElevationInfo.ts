
export async function buildJsIntegratedMeshLayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIntegratedMeshLayerElevationInfoGenerated } = await import('./integratedMeshLayerElevationInfo.gb');
    return await buildJsIntegratedMeshLayerElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIntegratedMeshLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetIntegratedMeshLayerElevationInfoGenerated } = await import('./integratedMeshLayerElevationInfo.gb');
    return await buildDotNetIntegratedMeshLayerElevationInfoGenerated(jsObject);
}
