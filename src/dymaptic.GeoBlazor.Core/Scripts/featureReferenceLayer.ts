
export async function buildJsFeatureReferenceLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureReferenceLayerGenerated } = await import('./featureReferenceLayer.gb');
    return await buildJsFeatureReferenceLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureReferenceLayer(jsObject: any): Promise<any> {
    let { buildDotNetFeatureReferenceLayerGenerated } = await import('./featureReferenceLayer.gb');
    return await buildDotNetFeatureReferenceLayerGenerated(jsObject);
}
