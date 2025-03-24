
export async function buildJsEditorWidgetVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorWidgetVisibleElementsGenerated } = await import('./editorWidgetVisibleElements.gb');
    return await buildJsEditorWidgetVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditorWidgetVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEditorWidgetVisibleElementsGenerated } = await import('./editorWidgetVisibleElements.gb');
    return await buildDotNetEditorWidgetVisibleElementsGenerated(jsObject, layerId, viewId);
}
