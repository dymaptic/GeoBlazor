
export async function buildJsRelationshipType(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsRelationshipTypeGenerated } = await import('./relationshipType.gb');
    return await buildJsRelationshipTypeGenerated(dotNetObject, viewId);
}     

export async function buildDotNetRelationshipType(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetRelationshipTypeGenerated } = await import('./relationshipType.gb');
    return await buildDotNetRelationshipTypeGenerated(jsObject, viewId);
}
