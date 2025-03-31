
export async function buildJsSnappingControlsVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSnappingControlsVisibleElementsGenerated } = await import('./snappingControlsVisibleElements.gb');
    return await buildJsSnappingControlsVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSnappingControlsVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSnappingControlsVisibleElementsGenerated } = await import('./snappingControlsVisibleElements.gb');
    return await buildDotNetSnappingControlsVisibleElementsGenerated(jsObject, layerId, viewId);
}
