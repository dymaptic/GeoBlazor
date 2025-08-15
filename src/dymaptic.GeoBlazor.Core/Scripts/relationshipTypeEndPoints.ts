
export async function buildJsRelationshipTypeEndPoints(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsRelationshipTypeEndPointsGenerated } = await import('./relationshipTypeEndPoints.gb');
    return await buildJsRelationshipTypeEndPointsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetRelationshipTypeEndPoints(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetRelationshipTypeEndPointsGenerated } = await import('./relationshipTypeEndPoints.gb');
    return await buildDotNetRelationshipTypeEndPointsGenerated(jsObject, viewId);
}
