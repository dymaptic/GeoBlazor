
export async function buildJsRelationshipSchemeForPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipSchemeForPointGenerated } = await import('./relationshipSchemeForPoint.gb');
    return await buildJsRelationshipSchemeForPointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelationshipSchemeForPoint(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipSchemeForPointGenerated } = await import('./relationshipSchemeForPoint.gb');
    return await buildDotNetRelationshipSchemeForPointGenerated(jsObject);
}
