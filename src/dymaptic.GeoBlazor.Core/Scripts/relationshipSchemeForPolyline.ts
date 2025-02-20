export async function buildJsRelationshipSchemeForPolyline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRelationshipSchemeForPolylineGenerated} = await import('./relationshipSchemeForPolyline.gb');
    return await buildJsRelationshipSchemeForPolylineGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRelationshipSchemeForPolyline(jsObject: any): Promise<any> {
    let {buildDotNetRelationshipSchemeForPolylineGenerated} = await import('./relationshipSchemeForPolyline.gb');
    return await buildDotNetRelationshipSchemeForPolylineGenerated(jsObject);
}
