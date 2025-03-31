
export async function buildJsFeatureLayerSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureLayerSourceGenerated } = await import('./featureLayerSource.gb');
    return await buildJsFeatureLayerSourceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureLayerSource(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureLayerSourceGenerated } = await import('./featureLayerSource.gb');
    return await buildDotNetFeatureLayerSourceGenerated(jsObject, layerId, viewId);
}
