
export async function buildJsEditorItem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorItemGenerated } = await import('./editorItem.gb');
    return await buildJsEditorItemGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditorItem(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEditorItemGenerated } = await import('./editorItem.gb');
    return await buildDotNetEditorItemGenerated(jsObject, layerId, viewId);
}
