
export async function buildJsFeatureViewModelLayerInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureViewModelLayerInfoGenerated } = await import('./featureViewModelLayerInfo.gb');
    return await buildJsFeatureViewModelLayerInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureViewModelLayerInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureViewModelLayerInfoGenerated } = await import('./featureViewModelLayerInfo.gb');
    return await buildDotNetFeatureViewModelLayerInfoGenerated(jsObject, viewId);
}
