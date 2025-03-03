
export async function buildJsTessellatedMesh(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTessellatedMeshGenerated } = await import('./tessellatedMesh.gb');
    return await buildJsTessellatedMeshGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTessellatedMesh(jsObject: any): Promise<any> {
    let { buildDotNetTessellatedMeshGenerated } = await import('./tessellatedMesh.gb');
    return await buildDotNetTessellatedMeshGenerated(jsObject);
}
