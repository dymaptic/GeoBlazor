
export async function buildJsMapNotesLayerCapabilitiesOperations(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsMapNotesLayerCapabilitiesOperationsGenerated } = await import('./mapNotesLayerCapabilitiesOperations.gb');
    return await buildJsMapNotesLayerCapabilitiesOperationsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetMapNotesLayerCapabilitiesOperations(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetMapNotesLayerCapabilitiesOperationsGenerated } = await import('./mapNotesLayerCapabilitiesOperations.gb');
    return await buildDotNetMapNotesLayerCapabilitiesOperationsGenerated(jsObject, viewId);
}
