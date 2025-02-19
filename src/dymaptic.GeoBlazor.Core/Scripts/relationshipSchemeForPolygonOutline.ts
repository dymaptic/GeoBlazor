export async function buildJsRelationshipSchemeForPolygonOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipSchemeForPolygonOutlineGenerated } = await import('./relationshipSchemeForPolygonOutline.gb');
    return await buildJsRelationshipSchemeForPolygonOutlineGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetRelationshipSchemeForPolygonOutline(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipSchemeForPolygonOutlineGenerated } = await import('./relationshipSchemeForPolygonOutline.gb');
    return await buildDotNetRelationshipSchemeForPolygonOutlineGenerated(jsObject);
}
