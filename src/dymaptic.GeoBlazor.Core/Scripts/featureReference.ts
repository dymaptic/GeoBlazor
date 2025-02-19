export async function buildJsFeatureReference(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureReferenceGenerated } = await import('./featureReference.gb');
    return await buildJsFeatureReferenceGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetFeatureReference(jsObject: any): Promise<any> {
    let { buildDotNetFeatureReferenceGenerated } = await import('./featureReference.gb');
    return await buildDotNetFeatureReferenceGenerated(jsObject);
}
