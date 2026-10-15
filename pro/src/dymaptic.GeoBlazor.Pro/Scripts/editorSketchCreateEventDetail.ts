
export async function buildJsEditorSketchCreateEventDetail(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorSketchCreateEventDetailGenerated } = await import('./editorSketchCreateEventDetail.gb');
    return await buildJsEditorSketchCreateEventDetailGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditorSketchCreateEventDetail(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEditorSketchCreateEventDetailGenerated } = await import('./editorSketchCreateEventDetail.gb');
    return await buildDotNetEditorSketchCreateEventDetailGenerated(jsObject, layerId, viewId);
}
