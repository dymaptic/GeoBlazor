
export async function buildJsIFeatureEffectLayer(dotNetObject: any): Promise<any> {
    let { buildJsIFeatureEffectLayerGenerated } = await import('./iFeatureEffectLayer.gb');
    return await buildJsIFeatureEffectLayerGenerated(dotNetObject);
}     

export async function buildDotNetIFeatureEffectLayer(jsObject: any): Promise<any> {
    let { buildDotNetIFeatureEffectLayerGenerated } = await import('./iFeatureEffectLayer.gb');
    return await buildDotNetIFeatureEffectLayerGenerated(jsObject);
}
