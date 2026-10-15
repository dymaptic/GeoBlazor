
export async function buildJsSnappingControlsElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSnappingControlsElementsGenerated } = await import('./snappingControlsElements.gb');
    return await buildJsSnappingControlsElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSnappingControlsElements(jsObject: any): Promise<any> {
    let { buildDotNetSnappingControlsElementsGenerated } = await import('./snappingControlsElements.gb');
    return await buildDotNetSnappingControlsElementsGenerated(jsObject);
}
