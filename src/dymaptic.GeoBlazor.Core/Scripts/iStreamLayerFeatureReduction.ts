
export async function buildJsIStreamLayerFeatureReduction(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIStreamLayerFeatureReductionGenerated } = await import('./iStreamLayerFeatureReduction.gb');
    return await buildJsIStreamLayerFeatureReductionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIStreamLayerFeatureReduction(jsObject: any): Promise<any> {
    let { buildDotNetIStreamLayerFeatureReductionGenerated } = await import('./iStreamLayerFeatureReduction.gb');
    return await buildDotNetIStreamLayerFeatureReductionGenerated(jsObject);
}
