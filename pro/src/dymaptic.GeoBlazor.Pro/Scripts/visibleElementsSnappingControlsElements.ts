
export async function buildJsVisibleElementsSnappingControlsElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVisibleElementsSnappingControlsElementsGenerated } = await import('./visibleElementsSnappingControlsElements.gb');
    return await buildJsVisibleElementsSnappingControlsElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVisibleElementsSnappingControlsElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVisibleElementsSnappingControlsElementsGenerated } = await import('./visibleElementsSnappingControlsElements.gb');
    return await buildDotNetVisibleElementsSnappingControlsElementsGenerated(jsObject, layerId, viewId);
}
