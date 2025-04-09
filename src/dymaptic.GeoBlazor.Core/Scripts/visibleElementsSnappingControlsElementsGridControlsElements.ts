
export async function buildJsVisibleElementsSnappingControlsElementsGridControlsElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVisibleElementsSnappingControlsElementsGridControlsElementsGenerated } = await import('./visibleElementsSnappingControlsElementsGridControlsElements.gb');
    return await buildJsVisibleElementsSnappingControlsElementsGridControlsElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVisibleElementsSnappingControlsElementsGridControlsElements(jsObject: any): Promise<any> {
    let { buildDotNetVisibleElementsSnappingControlsElementsGridControlsElementsGenerated } = await import('./visibleElementsSnappingControlsElementsGridControlsElements.gb');
    return await buildDotNetVisibleElementsSnappingControlsElementsGridControlsElementsGenerated(jsObject);
}
