
export async function buildJsEditorViewModelSketchCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorViewModelSketchCreateEventGenerated } = await import('./editorViewModelSketchCreateEvent.gb');
    return await buildJsEditorViewModelSketchCreateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditorViewModelSketchCreateEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEditorViewModelSketchCreateEventGenerated } = await import('./editorViewModelSketchCreateEvent.gb');
    return await buildDotNetEditorViewModelSketchCreateEventGenerated(jsObject, layerId, viewId);
}
