
export async function buildJsSnappingControlsElementsGridControlsElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSnappingControlsElementsGridControlsElementsGenerated } = await import('./snappingControlsElementsGridControlsElements.gb');
    return await buildJsSnappingControlsElementsGridControlsElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSnappingControlsElementsGridControlsElements(jsObject: any): Promise<any> {
    let { buildDotNetSnappingControlsElementsGridControlsElementsGenerated } = await import('./snappingControlsElementsGridControlsElements.gb');
    return await buildDotNetSnappingControlsElementsGridControlsElementsGenerated(jsObject);
}
