
export async function buildJsSketchViewModelCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchViewModelCreateEventGenerated } = await import('./sketchViewModelCreateEvent.gb');
    return await buildJsSketchViewModelCreateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchViewModelCreateEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSketchViewModelCreateEventGenerated } = await import('./sketchViewModelCreateEvent.gb');
    return await buildDotNetSketchViewModelCreateEventGenerated(jsObject, layerId, viewId);
}
