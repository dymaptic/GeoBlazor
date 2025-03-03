
export async function buildJsMapNotesLayerCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMapNotesLayerCapabilitiesGenerated } = await import('./mapNotesLayerCapabilities.gb');
    return await buildJsMapNotesLayerCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMapNotesLayerCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetMapNotesLayerCapabilitiesGenerated } = await import('./mapNotesLayerCapabilities.gb');
    return await buildDotNetMapNotesLayerCapabilitiesGenerated(jsObject);
}
