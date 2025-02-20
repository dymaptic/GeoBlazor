export async function buildJsRelationshipSchemeForPolygon(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRelationshipSchemeForPolygonGenerated} = await import('./relationshipSchemeForPolygon.gb');
    return await buildJsRelationshipSchemeForPolygonGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRelationshipSchemeForPolygon(jsObject: any): Promise<any> {
    let {buildDotNetRelationshipSchemeForPolygonGenerated} = await import('./relationshipSchemeForPolygon.gb');
    return await buildDotNetRelationshipSchemeForPolygonGenerated(jsObject);
}
