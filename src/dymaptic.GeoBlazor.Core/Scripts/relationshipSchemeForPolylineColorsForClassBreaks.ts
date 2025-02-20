export async function buildJsRelationshipSchemeForPolylineColorsForClassBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRelationshipSchemeForPolylineColorsForClassBreaksGenerated} = await import('./relationshipSchemeForPolylineColorsForClassBreaks.gb');
    return await buildJsRelationshipSchemeForPolylineColorsForClassBreaksGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRelationshipSchemeForPolylineColorsForClassBreaks(jsObject: any): Promise<any> {
    let {buildDotNetRelationshipSchemeForPolylineColorsForClassBreaksGenerated} = await import('./relationshipSchemeForPolylineColorsForClassBreaks.gb');
    return await buildDotNetRelationshipSchemeForPolylineColorsForClassBreaksGenerated(jsObject);
}
