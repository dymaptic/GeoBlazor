
export async function buildJsSketchViewModelDeleteEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchViewModelDeleteEventGenerated } = await import('./sketchViewModelDeleteEvent.gb');
    return await buildJsSketchViewModelDeleteEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchViewModelDeleteEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSketchViewModelDeleteEventGenerated } = await import('./sketchViewModelDeleteEvent.gb');
    return await buildDotNetSketchViewModelDeleteEventGenerated(jsObject, layerId, viewId);
}
