
export async function buildJsVisibleElementsSelectionTools(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVisibleElementsSelectionToolsGenerated } = await import('./visibleElementsSelectionTools.gb');
    return await buildJsVisibleElementsSelectionToolsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVisibleElementsSelectionTools(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVisibleElementsSelectionToolsGenerated } = await import('./visibleElementsSelectionTools.gb');
    return await buildDotNetVisibleElementsSelectionToolsGenerated(jsObject, layerId, viewId);
}
