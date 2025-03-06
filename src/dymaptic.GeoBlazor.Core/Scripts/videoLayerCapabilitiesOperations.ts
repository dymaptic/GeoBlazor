
export async function buildJsVideoLayerCapabilitiesOperations(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVideoLayerCapabilitiesOperationsGenerated } = await import('./videoLayerCapabilitiesOperations.gb');
    return await buildJsVideoLayerCapabilitiesOperationsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVideoLayerCapabilitiesOperations(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVideoLayerCapabilitiesOperationsGenerated } = await import('./videoLayerCapabilitiesOperations.gb');
    return await buildDotNetVideoLayerCapabilitiesOperationsGenerated(jsObject, layerId, viewId);
}
