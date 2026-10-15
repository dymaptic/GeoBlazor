
export async function buildJsEditorSketchUpdateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorSketchUpdateEventGenerated } = await import('./editorSketchUpdateEvent.gb');
    return await buildJsEditorSketchUpdateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditorSketchUpdateEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEditorSketchUpdateEventGenerated } = await import('./editorSketchUpdateEvent.gb');
    return await buildDotNetEditorSketchUpdateEventGenerated(jsObject, layerId, viewId);
}
