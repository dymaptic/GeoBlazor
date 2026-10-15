
export async function buildJsEditorSketchUpdateEventDetail(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorSketchUpdateEventDetailGenerated } = await import('./editorSketchUpdateEventDetail.gb');
    return await buildJsEditorSketchUpdateEventDetailGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditorSketchUpdateEventDetail(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEditorSketchUpdateEventDetailGenerated } = await import('./editorSketchUpdateEventDetail.gb');
    return await buildDotNetEditorSketchUpdateEventDetailGenerated(jsObject, layerId, viewId);
}
