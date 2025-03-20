
export async function buildJsCapabilitiesEditing(dotNetObject: any): Promise<any> {
    let { buildJsCapabilitiesEditingGenerated } = await import('./capabilitiesEditing.gb');
    return await buildJsCapabilitiesEditingGenerated(dotNetObject);
}     

export async function buildDotNetCapabilitiesEditing(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesEditingGenerated } = await import('./capabilitiesEditing.gb');
    return await buildDotNetCapabilitiesEditingGenerated(jsObject);
}
