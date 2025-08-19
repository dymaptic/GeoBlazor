
export async function buildJsViewshedFeatureReference(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewshedFeatureReferenceGenerated } = await import('./viewshedFeatureReference.gb');
    return await buildJsViewshedFeatureReferenceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewshedFeatureReference(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetViewshedFeatureReferenceGenerated } = await import('./viewshedFeatureReference.gb');
    return await buildDotNetViewshedFeatureReferenceGenerated(jsObject, viewId);
}
