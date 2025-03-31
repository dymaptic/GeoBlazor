
export async function buildJsExternalReferenceSpatialReference(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsExternalReferenceSpatialReferenceGenerated } = await import('./externalReferenceSpatialReference.gb');
    return await buildJsExternalReferenceSpatialReferenceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetExternalReferenceSpatialReference(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetExternalReferenceSpatialReferenceGenerated } = await import('./externalReferenceSpatialReference.gb');
    return await buildDotNetExternalReferenceSpatialReferenceGenerated(jsObject, layerId, viewId);
}
