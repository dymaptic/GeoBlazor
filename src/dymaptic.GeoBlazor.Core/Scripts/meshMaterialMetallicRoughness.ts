
export async function buildJsMeshMaterialMetallicRoughness(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMeshMaterialMetallicRoughnessGenerated } = await import('./meshMaterialMetallicRoughness.gb');
    return await buildJsMeshMaterialMetallicRoughnessGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMeshMaterialMetallicRoughness(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetMeshMaterialMetallicRoughnessGenerated } = await import('./meshMaterialMetallicRoughness.gb');
    return await buildDotNetMeshMaterialMetallicRoughnessGenerated(jsObject, viewId);
}
