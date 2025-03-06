
export async function buildJsMapNotesLayerCapabilitiesOperations(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMapNotesLayerCapabilitiesOperationsGenerated } = await import('./mapNotesLayerCapabilitiesOperations.gb');
    return await buildJsMapNotesLayerCapabilitiesOperationsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMapNotesLayerCapabilitiesOperations(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetMapNotesLayerCapabilitiesOperationsGenerated } = await import('./mapNotesLayerCapabilitiesOperations.gb');
    return await buildDotNetMapNotesLayerCapabilitiesOperationsGenerated(jsObject, layerId, viewId);
}
