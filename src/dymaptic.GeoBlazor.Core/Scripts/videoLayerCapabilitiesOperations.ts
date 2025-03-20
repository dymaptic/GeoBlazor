
export async function buildJsVideoLayerCapabilitiesOperations(dotNetObject: any): Promise<any> {
    let { buildJsVideoLayerCapabilitiesOperationsGenerated } = await import('./videoLayerCapabilitiesOperations.gb');
    return await buildJsVideoLayerCapabilitiesOperationsGenerated(dotNetObject);
}     

export async function buildDotNetVideoLayerCapabilitiesOperations(jsObject: any): Promise<any> {
    let { buildDotNetVideoLayerCapabilitiesOperationsGenerated } = await import('./videoLayerCapabilitiesOperations.gb');
    return await buildDotNetVideoLayerCapabilitiesOperationsGenerated(jsObject);
}
