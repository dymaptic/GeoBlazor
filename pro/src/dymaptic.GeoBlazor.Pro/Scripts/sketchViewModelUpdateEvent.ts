
export async function buildJsSketchViewModelUpdateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchViewModelUpdateEventGenerated } = await import('./sketchViewModelUpdateEvent.gb');
    return await buildJsSketchViewModelUpdateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchViewModelUpdateEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSketchViewModelUpdateEventGenerated } = await import('./sketchViewModelUpdateEvent.gb');
    return await buildDotNetSketchViewModelUpdateEventGenerated(jsObject, layerId, viewId);
}
