export async function buildJsRelationshipSchemeForMeshColorsForClassBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRelationshipSchemeForMeshColorsForClassBreaksGenerated} = await import('./relationshipSchemeForMeshColorsForClassBreaks.gb');
    return await buildJsRelationshipSchemeForMeshColorsForClassBreaksGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRelationshipSchemeForMeshColorsForClassBreaks(jsObject: any): Promise<any> {
    let {buildDotNetRelationshipSchemeForMeshColorsForClassBreaksGenerated} = await import('./relationshipSchemeForMeshColorsForClassBreaks.gb');
    return await buildDotNetRelationshipSchemeForMeshColorsForClassBreaksGenerated(jsObject);
}
