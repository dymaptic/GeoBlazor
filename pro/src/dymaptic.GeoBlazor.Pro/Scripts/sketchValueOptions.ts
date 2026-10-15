
export async function buildJsSketchValueOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchValueOptionsGenerated } = await import('./sketchValueOptions.gb');
    return await buildJsSketchValueOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchValueOptions(jsObject: any): Promise<any> {
    let { buildDotNetSketchValueOptionsGenerated } = await import('./sketchValueOptions.gb');
    return await buildDotNetSketchValueOptionsGenerated(jsObject);
}
