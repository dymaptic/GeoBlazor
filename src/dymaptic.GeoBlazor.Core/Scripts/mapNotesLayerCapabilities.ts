
export async function buildJsMapNotesLayerCapabilities(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsMapNotesLayerCapabilitiesGenerated } = await import('./mapNotesLayerCapabilities.gb');
    return await buildJsMapNotesLayerCapabilitiesGenerated(dotNetObject, viewId);
}     

export async function buildDotNetMapNotesLayerCapabilities(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetMapNotesLayerCapabilitiesGenerated } = await import('./mapNotesLayerCapabilities.gb');
    return await buildDotNetMapNotesLayerCapabilitiesGenerated(jsObject, viewId);
}
