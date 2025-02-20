// override generated code in this file

export async function buildJsRelationshipQuery(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRelationshipQueryGenerated} = await import('./relationshipQuery.gb');
    return await buildJsRelationshipQueryGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRelationshipQuery(jsObject: any): Promise<any> {
    let {buildDotNetRelationshipQueryGenerated} = await import('./relationshipQuery.gb');
    return await buildDotNetRelationshipQueryGenerated(jsObject);
}
