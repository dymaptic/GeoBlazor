
export async function buildJsFeatureServiceResourcesBundle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureServiceResourcesBundleGenerated } = await import('./featureServiceResourcesBundle.gb');
    return await buildJsFeatureServiceResourcesBundleGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureServiceResourcesBundle(jsObject: any): Promise<any> {
    let { buildDotNetFeatureServiceResourcesBundleGenerated } = await import('./featureServiceResourcesBundle.gb');
    return await buildDotNetFeatureServiceResourcesBundleGenerated(jsObject);
}
