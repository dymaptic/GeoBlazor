
export async function buildJsSketchViewModelRedoEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchViewModelRedoEventGenerated } = await import('./sketchViewModelRedoEvent.gb');
    return await buildJsSketchViewModelRedoEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchViewModelRedoEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSketchViewModelRedoEventGenerated } = await import('./sketchViewModelRedoEvent.gb');
    return await buildDotNetSketchViewModelRedoEventGenerated(jsObject, layerId, viewId);
}
