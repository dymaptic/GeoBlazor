
export async function buildJsFeatureReductionBinning(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureReductionBinningGenerated } = await import('./featureReductionBinning.gb');
    return await buildJsFeatureReductionBinningGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureReductionBinning(jsObject: any): Promise<any> {
    let { buildDotNetFeatureReductionBinningGenerated } = await import('./featureReductionBinning.gb');
    return await buildDotNetFeatureReductionBinningGenerated(jsObject);
}
