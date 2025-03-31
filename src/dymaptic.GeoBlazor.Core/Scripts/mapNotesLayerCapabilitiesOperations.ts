
export async function buildJsMapNotesLayerCapabilitiesOperations(dotNetObject: any): Promise<any> {
    let { buildJsMapNotesLayerCapabilitiesOperationsGenerated } = await import('./mapNotesLayerCapabilitiesOperations.gb');
    return await buildJsMapNotesLayerCapabilitiesOperationsGenerated(dotNetObject);
}     

export async function buildDotNetMapNotesLayerCapabilitiesOperations(jsObject: any): Promise<any> {
    let { buildDotNetMapNotesLayerCapabilitiesOperationsGenerated } = await import('./mapNotesLayerCapabilitiesOperations.gb');
    return await buildDotNetMapNotesLayerCapabilitiesOperationsGenerated(jsObject);
}
