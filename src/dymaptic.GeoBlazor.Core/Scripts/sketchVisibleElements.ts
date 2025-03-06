
export async function buildJsSketchVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchVisibleElementsGenerated } = await import('./sketchVisibleElements.gb');
    return await buildJsSketchVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSketchVisibleElementsGenerated } = await import('./sketchVisibleElements.gb');
    return await buildDotNetSketchVisibleElementsGenerated(jsObject, layerId, viewId);
}
