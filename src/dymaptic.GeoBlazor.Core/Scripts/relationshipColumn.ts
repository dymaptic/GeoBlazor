
export async function buildJsRelationshipColumn(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipColumnGenerated } = await import('./relationshipColumn.gb');
    return await buildJsRelationshipColumnGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelationshipColumn(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipColumnGenerated } = await import('./relationshipColumn.gb');
    return await buildDotNetRelationshipColumnGenerated(jsObject);
}
