
export async function buildJsIFeatureEffectLayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIFeatureEffectLayerGenerated } = await import('./iFeatureEffectLayer.gb');
    return await buildJsIFeatureEffectLayerGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIFeatureEffectLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIFeatureEffectLayerGenerated } = await import('./iFeatureEffectLayer.gb');
    return await buildDotNetIFeatureEffectLayerGenerated(jsObject, viewId);
}
