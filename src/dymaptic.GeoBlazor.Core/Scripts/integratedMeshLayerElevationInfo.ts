
export async function buildJsIntegratedMeshLayerElevationInfo(dotNetObject: any): Promise<any> {
    let { buildJsIntegratedMeshLayerElevationInfoGenerated } = await import('./integratedMeshLayerElevationInfo.gb');
    return await buildJsIntegratedMeshLayerElevationInfoGenerated(dotNetObject);
}     

export async function buildDotNetIntegratedMeshLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetIntegratedMeshLayerElevationInfoGenerated } = await import('./integratedMeshLayerElevationInfo.gb');
    return await buildDotNetIntegratedMeshLayerElevationInfoGenerated(jsObject);
}
