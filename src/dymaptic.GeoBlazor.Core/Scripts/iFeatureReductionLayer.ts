
export async function buildJsIFeatureReductionLayer(dotNetObject: any): Promise<any> {
    let { buildJsIFeatureReductionLayerGenerated } = await import('./iFeatureReductionLayer.gb');
    return await buildJsIFeatureReductionLayerGenerated(dotNetObject);
}     

export async function buildDotNetIFeatureReductionLayer(jsObject: any): Promise<any> {
    let { buildDotNetIFeatureReductionLayerGenerated } = await import('./iFeatureReductionLayer.gb');
    return await buildDotNetIFeatureReductionLayerGenerated(jsObject);
}
