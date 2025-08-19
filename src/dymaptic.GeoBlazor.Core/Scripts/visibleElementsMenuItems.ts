
export async function buildJsVisibleElementsMenuItems(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVisibleElementsMenuItemsGenerated } = await import('./visibleElementsMenuItems.gb');
    return await buildJsVisibleElementsMenuItemsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVisibleElementsMenuItems(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVisibleElementsMenuItemsGenerated } = await import('./visibleElementsMenuItems.gb');
    return await buildDotNetVisibleElementsMenuItemsGenerated(jsObject, viewId);
}
