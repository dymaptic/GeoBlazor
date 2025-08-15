// override generated code in this file

export async function buildJsRelationshipQuery(dotNetObject: any, viewId: string | null): Promise<any> {
    let {buildJsRelationshipQueryGenerated} = await import('./relationshipQuery.gb');
    return await buildJsRelationshipQueryGenerated(dotNetObject, viewId);
}

export async function buildDotNetRelationshipQuery(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetRelationshipQueryGenerated} = await import('./relationshipQuery.gb');
    return await buildDotNetRelationshipQueryGenerated(jsObject, viewId);
}
