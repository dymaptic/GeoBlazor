
export async function buildJsVisibleElementsColumnMenuItems(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVisibleElementsColumnMenuItemsGenerated } = await import('./visibleElementsColumnMenuItems.gb');
    return await buildJsVisibleElementsColumnMenuItemsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVisibleElementsColumnMenuItems(jsObject: any): Promise<any> {
    let { buildDotNetVisibleElementsColumnMenuItemsGenerated } = await import('./visibleElementsColumnMenuItems.gb');
    return await buildDotNetVisibleElementsColumnMenuItemsGenerated(jsObject);
}
