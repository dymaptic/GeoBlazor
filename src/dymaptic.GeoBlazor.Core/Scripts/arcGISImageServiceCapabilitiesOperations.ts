
export async function buildJsArcGISImageServiceCapabilitiesOperations(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsArcGISImageServiceCapabilitiesOperationsGenerated } = await import('./arcGISImageServiceCapabilitiesOperations.gb');
    return await buildJsArcGISImageServiceCapabilitiesOperationsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetArcGISImageServiceCapabilitiesOperations(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetArcGISImageServiceCapabilitiesOperationsGenerated } = await import('./arcGISImageServiceCapabilitiesOperations.gb');
    return await buildDotNetArcGISImageServiceCapabilitiesOperationsGenerated(jsObject, viewId);
}
