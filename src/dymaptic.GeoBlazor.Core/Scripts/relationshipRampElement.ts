export async function buildJsRelationshipRampElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRelationshipRampElementGenerated} = await import('./relationshipRampElement.gb');
    return await buildJsRelationshipRampElementGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRelationshipRampElement(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetRelationshipRampElementGenerated} = await import('./relationshipRampElement.gb');
    return await buildDotNetRelationshipRampElementGenerated(jsObject, layerId, viewId);
}
