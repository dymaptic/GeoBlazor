
export async function buildJsRelationshipType(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipTypeGenerated } = await import('./relationshipType.gb');
    return await buildJsRelationshipTypeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelationshipType(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipTypeGenerated } = await import('./relationshipType.gb');
    return await buildDotNetRelationshipTypeGenerated(jsObject);
}
