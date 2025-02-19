
export async function buildJsRelationshipSchemeForPolygonColorsForClassBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipSchemeForPolygonColorsForClassBreaksGenerated } = await import('./relationshipSchemeForPolygonColorsForClassBreaks.gb');
    return await buildJsRelationshipSchemeForPolygonColorsForClassBreaksGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelationshipSchemeForPolygonColorsForClassBreaks(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipSchemeForPolygonColorsForClassBreaksGenerated } = await import('./relationshipSchemeForPolygonColorsForClassBreaks.gb');
    return await buildDotNetRelationshipSchemeForPolygonColorsForClassBreaksGenerated(jsObject);
}
