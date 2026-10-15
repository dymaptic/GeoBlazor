
export async function buildJsEditorViewModelSketchUpdateEventDetail(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorViewModelSketchUpdateEventDetailGenerated } = await import('./editorViewModelSketchUpdateEventDetail.gb');
    return await buildJsEditorViewModelSketchUpdateEventDetailGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditorViewModelSketchUpdateEventDetail(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEditorViewModelSketchUpdateEventDetailGenerated } = await import('./editorViewModelSketchUpdateEventDetail.gb');
    return await buildDotNetEditorViewModelSketchUpdateEventDetailGenerated(jsObject, layerId, viewId);
}
