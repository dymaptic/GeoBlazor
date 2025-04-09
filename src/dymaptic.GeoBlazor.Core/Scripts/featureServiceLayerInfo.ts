
export async function buildJsFeatureServiceLayerInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureServiceLayerInfoGenerated } = await import('./featureServiceLayerInfo.gb');
    return await buildJsFeatureServiceLayerInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureServiceLayerInfo(jsObject: any): Promise<any> {
    let { buildDotNetFeatureServiceLayerInfoGenerated } = await import('./featureServiceLayerInfo.gb');
    return await buildDotNetFeatureServiceLayerInfoGenerated(jsObject);
}
