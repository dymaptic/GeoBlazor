export async function buildJsFeatureSnappingLayerSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureSnappingLayerSourceGenerated} = await import('./featureSnappingLayerSource.gb');
    return await buildJsFeatureSnappingLayerSourceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureSnappingLayerSource(jsObject: any): Promise<any> {
    let {buildDotNetFeatureSnappingLayerSourceGenerated} = await import('./featureSnappingLayerSource.gb');
    return await buildDotNetFeatureSnappingLayerSourceGenerated(jsObject);
}
