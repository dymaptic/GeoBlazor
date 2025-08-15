
export async function buildJsIntegratedMeshLayerElevationInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIntegratedMeshLayerElevationInfoGenerated } = await import('./integratedMeshLayerElevationInfo.gb');
    return await buildJsIntegratedMeshLayerElevationInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIntegratedMeshLayerElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIntegratedMeshLayerElevationInfoGenerated } = await import('./integratedMeshLayerElevationInfo.gb');
    return await buildDotNetIntegratedMeshLayerElevationInfoGenerated(jsObject, viewId);
}
