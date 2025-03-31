
export async function buildJsArcGISImageServiceCapabilitiesOperations(dotNetObject: any): Promise<any> {
    let { buildJsArcGISImageServiceCapabilitiesOperationsGenerated } = await import('./arcGISImageServiceCapabilitiesOperations.gb');
    return await buildJsArcGISImageServiceCapabilitiesOperationsGenerated(dotNetObject);
}     

export async function buildDotNetArcGISImageServiceCapabilitiesOperations(jsObject: any): Promise<any> {
    let { buildDotNetArcGISImageServiceCapabilitiesOperationsGenerated } = await import('./arcGISImageServiceCapabilitiesOperations.gb');
    return await buildDotNetArcGISImageServiceCapabilitiesOperationsGenerated(jsObject);
}
