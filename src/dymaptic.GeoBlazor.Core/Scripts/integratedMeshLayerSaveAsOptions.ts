
export async function buildJsIntegratedMeshLayerSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIntegratedMeshLayerSaveAsOptionsGenerated } = await import('./integratedMeshLayerSaveAsOptions.gb');
    return await buildJsIntegratedMeshLayerSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIntegratedMeshLayerSaveAsOptions(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIntegratedMeshLayerSaveAsOptionsGenerated } = await import('./integratedMeshLayerSaveAsOptions.gb');
    return await buildDotNetIntegratedMeshLayerSaveAsOptionsGenerated(jsObject, viewId);
}
