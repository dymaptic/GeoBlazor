
export async function buildJsFeatureEffect(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureEffectGenerated } = await import('./featureEffect.gb');
    return await buildJsFeatureEffectGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureEffect(jsObject: any): Promise<any> {
    let { buildDotNetFeatureEffectGenerated } = await import('./featureEffect.gb');
    return await buildDotNetFeatureEffectGenerated(jsObject);
}
