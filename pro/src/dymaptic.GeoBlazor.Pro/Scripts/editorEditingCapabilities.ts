
export async function buildJsEditorEditingCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorEditingCapabilitiesGenerated } = await import('./editorEditingCapabilities.gb');
    return await buildJsEditorEditingCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditorEditingCapabilities(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEditorEditingCapabilitiesGenerated } = await import('./editorEditingCapabilities.gb');
    return await buildDotNetEditorEditingCapabilitiesGenerated(jsObject, layerId, viewId);
}
