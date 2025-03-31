
export async function buildJsMapNotesLayerCapabilities(dotNetObject: any): Promise<any> {
    let { buildJsMapNotesLayerCapabilitiesGenerated } = await import('./mapNotesLayerCapabilities.gb');
    return await buildJsMapNotesLayerCapabilitiesGenerated(dotNetObject);
}     

export async function buildDotNetMapNotesLayerCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetMapNotesLayerCapabilitiesGenerated } = await import('./mapNotesLayerCapabilities.gb');
    return await buildDotNetMapNotesLayerCapabilitiesGenerated(jsObject);
}
