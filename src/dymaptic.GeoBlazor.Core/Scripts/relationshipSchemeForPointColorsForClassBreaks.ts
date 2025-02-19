export async function buildJsRelationshipSchemeForPointColorsForClassBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipSchemeForPointColorsForClassBreaksGenerated } = await import('./relationshipSchemeForPointColorsForClassBreaks.gb');
    return await buildJsRelationshipSchemeForPointColorsForClassBreaksGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetRelationshipSchemeForPointColorsForClassBreaks(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipSchemeForPointColorsForClassBreaksGenerated } = await import('./relationshipSchemeForPointColorsForClassBreaks.gb');
    return await buildDotNetRelationshipSchemeForPointColorsForClassBreaksGenerated(jsObject);
}
