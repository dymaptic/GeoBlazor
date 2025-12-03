
export async function buildJsFeatureReferenceId(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureReferenceIdGenerated } = await import('./featureReferenceId.gb');
    return await buildJsFeatureReferenceIdGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureReferenceId(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureReferenceIdGenerated } = await import('./featureReferenceId.gb');
    return await buildDotNetFeatureReferenceIdGenerated(jsObject, viewId);
}
