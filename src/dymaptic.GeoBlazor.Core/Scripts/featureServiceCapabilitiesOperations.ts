
export async function buildJsFeatureServiceCapabilitiesOperations(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureServiceCapabilitiesOperationsGenerated } = await import('./featureServiceCapabilitiesOperations.gb');
    return await buildJsFeatureServiceCapabilitiesOperationsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureServiceCapabilitiesOperations(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureServiceCapabilitiesOperationsGenerated } = await import('./featureServiceCapabilitiesOperations.gb');
    return await buildDotNetFeatureServiceCapabilitiesOperationsGenerated(jsObject, layerId, viewId);
}
