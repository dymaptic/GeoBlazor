
export async function buildJsIOrientedImageryLayerFeatureReduction(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIOrientedImageryLayerFeatureReductionGenerated } = await import('./iOrientedImageryLayerFeatureReduction.gb');
    return await buildJsIOrientedImageryLayerFeatureReductionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIOrientedImageryLayerFeatureReduction(jsObject: any): Promise<any> {
    let { buildDotNetIOrientedImageryLayerFeatureReductionGenerated } = await import('./iOrientedImageryLayerFeatureReduction.gb');
    return await buildDotNetIOrientedImageryLayerFeatureReductionGenerated(jsObject);
}
