
export async function buildJsSketchViewModelUndoEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchViewModelUndoEventGenerated } = await import('./sketchViewModelUndoEvent.gb');
    return await buildJsSketchViewModelUndoEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchViewModelUndoEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSketchViewModelUndoEventGenerated } = await import('./sketchViewModelUndoEvent.gb');
    return await buildDotNetSketchViewModelUndoEventGenerated(jsObject, layerId, viewId);
}
