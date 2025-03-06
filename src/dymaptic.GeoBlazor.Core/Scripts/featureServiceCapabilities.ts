
export async function buildJsFeatureServiceCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureServiceCapabilitiesGenerated } = await import('./featureServiceCapabilities.gb');
    return await buildJsFeatureServiceCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureServiceCapabilities(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureServiceCapabilitiesGenerated } = await import('./featureServiceCapabilities.gb');
    return await buildDotNetFeatureServiceCapabilitiesGenerated(jsObject, layerId, viewId);
}
