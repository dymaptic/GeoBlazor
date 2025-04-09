
export async function buildJsGridControlsVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGridControlsVisibleElementsGenerated } = await import('./gridControlsVisibleElements.gb');
    return await buildJsGridControlsVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGridControlsVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetGridControlsVisibleElementsGenerated } = await import('./gridControlsVisibleElements.gb');
    return await buildDotNetGridControlsVisibleElementsGenerated(jsObject);
}
