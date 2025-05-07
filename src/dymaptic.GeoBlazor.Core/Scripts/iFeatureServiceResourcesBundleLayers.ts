
export async function buildJsIFeatureServiceResourcesBundleLayers(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIFeatureServiceResourcesBundleLayersGenerated } = await import('./iFeatureServiceResourcesBundleLayers.gb');
    return await buildJsIFeatureServiceResourcesBundleLayersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIFeatureServiceResourcesBundleLayers(jsObject: any): Promise<any> {
    let { buildDotNetIFeatureServiceResourcesBundleLayersGenerated } = await import('./iFeatureServiceResourcesBundleLayers.gb');
    return await buildDotNetIFeatureServiceResourcesBundleLayersGenerated(jsObject);
}
