
export async function buildJsEditorVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorVisibleElementsGenerated } = await import('./editorVisibleElements.gb');
    return await buildJsEditorVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditorVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEditorVisibleElementsGenerated } = await import('./editorVisibleElements.gb');
    return await buildDotNetEditorVisibleElementsGenerated(jsObject, layerId, viewId);
}
