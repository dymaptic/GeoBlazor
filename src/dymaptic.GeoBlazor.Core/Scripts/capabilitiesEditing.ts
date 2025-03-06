
export async function buildJsCapabilitiesEditing(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesEditingGenerated } = await import('./capabilitiesEditing.gb');
    return await buildJsCapabilitiesEditingGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCapabilitiesEditing(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCapabilitiesEditingGenerated } = await import('./capabilitiesEditing.gb');
    return await buildDotNetCapabilitiesEditingGenerated(jsObject, layerId, viewId);
}
