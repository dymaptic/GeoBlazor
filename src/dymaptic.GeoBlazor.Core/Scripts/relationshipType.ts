
export async function buildJsRelationshipType(dotNetObject: any): Promise<any> {
    let { buildJsRelationshipTypeGenerated } = await import('./relationshipType.gb');
    return await buildJsRelationshipTypeGenerated(dotNetObject);
}     

export async function buildDotNetRelationshipType(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipTypeGenerated } = await import('./relationshipType.gb');
    return await buildDotNetRelationshipTypeGenerated(jsObject);
}
