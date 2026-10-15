
export async function buildJsEditorSketchCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorSketchCreateEventGenerated } = await import('./editorSketchCreateEvent.gb');
    return await buildJsEditorSketchCreateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditorSketchCreateEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEditorSketchCreateEventGenerated } = await import('./editorSketchCreateEvent.gb');
    return await buildDotNetEditorSketchCreateEventGenerated(jsObject, layerId, viewId);
}
