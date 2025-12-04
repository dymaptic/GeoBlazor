
export async function buildJsMeshMaterialMetallicRoughness(dotNetObject: any): Promise<any> {
    let { buildJsMeshMaterialMetallicRoughnessGenerated } = await import('./meshMaterialMetallicRoughness.gb');
    return await buildJsMeshMaterialMetallicRoughnessGenerated(dotNetObject);
}     

export async function buildDotNetMeshMaterialMetallicRoughness(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetMeshMaterialMetallicRoughnessGenerated } = await import('./meshMaterialMetallicRoughness.gb');
    return await buildDotNetMeshMaterialMetallicRoughnessGenerated(jsObject, viewId);
}
