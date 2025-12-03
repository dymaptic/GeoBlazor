
export async function buildJsFeatureReferenceGlobalId(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureReferenceGlobalIdGenerated } = await import('./featureReferenceGlobalId.gb');
    return await buildJsFeatureReferenceGlobalIdGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureReferenceGlobalId(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureReferenceGlobalIdGenerated } = await import('./featureReferenceGlobalId.gb');
    return await buildDotNetFeatureReferenceGlobalIdGenerated(jsObject, viewId);
}
