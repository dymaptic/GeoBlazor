export async function buildJsRelationshipSchemeForPointOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRelationshipSchemeForPointOutlineGenerated} = await import('./relationshipSchemeForPointOutline.gb');
    return await buildJsRelationshipSchemeForPointOutlineGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRelationshipSchemeForPointOutline(jsObject: any): Promise<any> {
    let {buildDotNetRelationshipSchemeForPointOutlineGenerated} = await import('./relationshipSchemeForPointOutline.gb');
    return await buildDotNetRelationshipSchemeForPointOutlineGenerated(jsObject);
}
