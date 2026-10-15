
export async function buildJsEditorViewModelSketchCreateEventDetail(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorViewModelSketchCreateEventDetailGenerated } = await import('./editorViewModelSketchCreateEventDetail.gb');
    return await buildJsEditorViewModelSketchCreateEventDetailGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditorViewModelSketchCreateEventDetail(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEditorViewModelSketchCreateEventDetailGenerated } = await import('./editorViewModelSketchCreateEventDetail.gb');
    return await buildDotNetEditorViewModelSketchCreateEventDetailGenerated(jsObject, layerId, viewId);
}
