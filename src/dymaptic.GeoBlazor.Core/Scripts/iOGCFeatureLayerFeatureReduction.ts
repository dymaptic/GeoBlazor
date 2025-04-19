
export async function buildJsIOGCFeatureLayerFeatureReduction(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIOGCFeatureLayerFeatureReductionGenerated } = await import('./iOGCFeatureLayerFeatureReduction.gb');
    return await buildJsIOGCFeatureLayerFeatureReductionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIOGCFeatureLayerFeatureReduction(jsObject: any): Promise<any> {
    let { buildDotNetIOGCFeatureLayerFeatureReductionGenerated } = await import('./iOGCFeatureLayerFeatureReduction.gb');
    return await buildDotNetIOGCFeatureLayerFeatureReductionGenerated(jsObject);
}
