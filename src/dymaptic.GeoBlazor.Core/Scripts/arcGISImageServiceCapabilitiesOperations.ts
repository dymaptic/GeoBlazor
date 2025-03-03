
export async function buildJsArcGISImageServiceCapabilitiesOperations(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsArcGISImageServiceCapabilitiesOperationsGenerated } = await import('./arcGISImageServiceCapabilitiesOperations.gb');
    return await buildJsArcGISImageServiceCapabilitiesOperationsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetArcGISImageServiceCapabilitiesOperations(jsObject: any): Promise<any> {
    let { buildDotNetArcGISImageServiceCapabilitiesOperationsGenerated } = await import('./arcGISImageServiceCapabilitiesOperations.gb');
    return await buildDotNetArcGISImageServiceCapabilitiesOperationsGenerated(jsObject);
}
