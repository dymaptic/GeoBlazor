
export async function buildJsSwipeVisibleElements(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsSwipeVisibleElementsGenerated } = await import('./swipeVisibleElements.gb');
    return await buildJsSwipeVisibleElementsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetSwipeVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSwipeVisibleElementsGenerated } = await import('./swipeVisibleElements.gb');
    return await buildDotNetSwipeVisibleElementsGenerated(jsObject, viewId);
}
