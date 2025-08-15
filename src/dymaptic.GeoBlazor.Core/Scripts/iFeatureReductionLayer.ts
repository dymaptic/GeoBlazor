
export async function buildJsIFeatureReductionLayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIFeatureReductionLayerGenerated } = await import('./iFeatureReductionLayer.gb');
    return await buildJsIFeatureReductionLayerGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIFeatureReductionLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIFeatureReductionLayerGenerated } = await import('./iFeatureReductionLayer.gb');
    return await buildDotNetIFeatureReductionLayerGenerated(jsObject, viewId);
}
