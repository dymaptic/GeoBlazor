
export async function buildJsSwipeVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSwipeVisibleElementsGenerated } = await import('./swipeVisibleElements.gb');
    return await buildJsSwipeVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSwipeVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetSwipeVisibleElementsGenerated } = await import('./swipeVisibleElements.gb');
    return await buildDotNetSwipeVisibleElementsGenerated(jsObject);
}
