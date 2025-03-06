
export async function buildJsRelationshipTypeEndPoints(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipTypeEndPointsGenerated } = await import('./relationshipTypeEndPoints.gb');
    return await buildJsRelationshipTypeEndPointsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelationshipTypeEndPoints(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRelationshipTypeEndPointsGenerated } = await import('./relationshipTypeEndPoints.gb');
    return await buildDotNetRelationshipTypeEndPointsGenerated(jsObject, layerId, viewId);
}
