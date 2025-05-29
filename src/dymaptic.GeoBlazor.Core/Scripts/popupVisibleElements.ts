
export async function buildJsPopupVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPopupVisibleElementsGenerated } = await import('./popupVisibleElements.gb');
    return await buildJsPopupVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPopupVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPopupVisibleElementsGenerated } = await import('./popupVisibleElements.gb');
    return await buildDotNetPopupVisibleElementsGenerated(jsObject, layerId, viewId);
}
