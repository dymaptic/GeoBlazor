
export async function buildJsRelationshipSchemeForMesh(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipSchemeForMeshGenerated } = await import('./relationshipSchemeForMesh.gb');
    return await buildJsRelationshipSchemeForMeshGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelationshipSchemeForMesh(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipSchemeForMeshGenerated } = await import('./relationshipSchemeForMesh.gb');
    return await buildDotNetRelationshipSchemeForMeshGenerated(jsObject);
}
