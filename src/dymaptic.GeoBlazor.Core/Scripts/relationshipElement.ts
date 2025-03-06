export async function buildJsRelationshipElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRelationshipElementGenerated} = await import('./relationshipElement.gb');
    return await buildJsRelationshipElementGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRelationshipElement(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetRelationshipElementGenerated} = await import('./relationshipElement.gb');
    return await buildDotNetRelationshipElementGenerated(jsObject, layerId, viewId);
}
