
export async function buildJsRelationshipTypeEndPoints(dotNetObject: any): Promise<any> {
    let { buildJsRelationshipTypeEndPointsGenerated } = await import('./relationshipTypeEndPoints.gb');
    return await buildJsRelationshipTypeEndPointsGenerated(dotNetObject);
}     

export async function buildDotNetRelationshipTypeEndPoints(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipTypeEndPointsGenerated } = await import('./relationshipTypeEndPoints.gb');
    return await buildDotNetRelationshipTypeEndPointsGenerated(jsObject);
}
