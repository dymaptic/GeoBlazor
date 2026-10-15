
export async function buildJsEditorViewModelSketchUpdateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorViewModelSketchUpdateEventGenerated } = await import('./editorViewModelSketchUpdateEvent.gb');
    return await buildJsEditorViewModelSketchUpdateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditorViewModelSketchUpdateEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEditorViewModelSketchUpdateEventGenerated } = await import('./editorViewModelSketchUpdateEvent.gb');
    return await buildDotNetEditorViewModelSketchUpdateEventGenerated(jsObject, layerId, viewId);
}
