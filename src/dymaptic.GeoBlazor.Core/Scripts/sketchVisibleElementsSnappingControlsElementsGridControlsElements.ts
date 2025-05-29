
export async function buildJsSketchVisibleElementsSnappingControlsElementsGridControlsElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchVisibleElementsSnappingControlsElementsGridControlsElementsGenerated } = await import('./sketchVisibleElementsSnappingControlsElementsGridControlsElements.gb');
    return await buildJsSketchVisibleElementsSnappingControlsElementsGridControlsElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchVisibleElementsSnappingControlsElementsGridControlsElements(jsObject: any): Promise<any> {
    let { buildDotNetSketchVisibleElementsSnappingControlsElementsGridControlsElementsGenerated } = await import('./sketchVisibleElementsSnappingControlsElementsGridControlsElements.gb');
    return await buildDotNetSketchVisibleElementsSnappingControlsElementsGridControlsElementsGenerated(jsObject);
}
