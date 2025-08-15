
export async function buildJsVideoLayerCapabilitiesOperations(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsVideoLayerCapabilitiesOperationsGenerated } = await import('./videoLayerCapabilitiesOperations.gb');
    return await buildJsVideoLayerCapabilitiesOperationsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetVideoLayerCapabilitiesOperations(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVideoLayerCapabilitiesOperationsGenerated } = await import('./videoLayerCapabilitiesOperations.gb');
    return await buildDotNetVideoLayerCapabilitiesOperationsGenerated(jsObject, viewId);
}
