
export async function buildJsRelationshipSchemes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipSchemesGenerated } = await import('./relationshipSchemes.gb');
    return await buildJsRelationshipSchemesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelationshipSchemes(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipSchemesGenerated } = await import('./relationshipSchemes.gb');
    return await buildDotNetRelationshipSchemesGenerated(jsObject);
}
