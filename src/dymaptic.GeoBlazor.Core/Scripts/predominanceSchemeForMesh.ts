export async function buildJsPredominanceSchemeForMesh(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPredominanceSchemeForMeshGenerated } = await import('./predominanceSchemeForMesh.gb');
    return await buildJsPredominanceSchemeForMeshGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPredominanceSchemeForMesh(jsObject: any): Promise<any> {
    let { buildDotNetPredominanceSchemeForMeshGenerated } = await import('./predominanceSchemeForMesh.gb');
    return await buildDotNetPredominanceSchemeForMeshGenerated(jsObject);
}
