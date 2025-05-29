
export async function buildJsSketchVisibleElementsSnappingControlsElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchVisibleElementsSnappingControlsElementsGenerated } = await import('./sketchVisibleElementsSnappingControlsElements.gb');
    return await buildJsSketchVisibleElementsSnappingControlsElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchVisibleElementsSnappingControlsElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSketchVisibleElementsSnappingControlsElementsGenerated } = await import('./sketchVisibleElementsSnappingControlsElements.gb');
    return await buildDotNetSketchVisibleElementsSnappingControlsElementsGenerated(jsObject, layerId, viewId);
}
