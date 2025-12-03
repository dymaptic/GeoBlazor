
export async function buildJsFeatureReferenceObjectId(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureReferenceObjectIdGenerated } = await import('./featureReferenceObjectId.gb');
    return await buildJsFeatureReferenceObjectIdGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureReferenceObjectId(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureReferenceObjectIdGenerated } = await import('./featureReferenceObjectId.gb');
    return await buildDotNetFeatureReferenceObjectIdGenerated(jsObject, viewId);
}
