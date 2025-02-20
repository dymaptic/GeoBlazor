export async function buildJsRelationshipInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRelationshipInputGenerated} = await import('./relationshipInput.gb');
    return await buildJsRelationshipInputGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRelationshipInput(jsObject: any): Promise<any> {
    let {buildDotNetRelationshipInputGenerated} = await import('./relationshipInput.gb');
    return await buildDotNetRelationshipInputGenerated(jsObject);
}
