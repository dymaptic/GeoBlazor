
export async function buildJsFeatureServiceCapabilitiesData(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureServiceCapabilitiesDataGenerated } = await import('./featureServiceCapabilitiesData.gb');
    return await buildJsFeatureServiceCapabilitiesDataGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureServiceCapabilitiesData(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureServiceCapabilitiesDataGenerated } = await import('./featureServiceCapabilitiesData.gb');
    return await buildDotNetFeatureServiceCapabilitiesDataGenerated(jsObject, layerId, viewId);
}
