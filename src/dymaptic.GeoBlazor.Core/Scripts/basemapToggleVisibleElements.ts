
export async function buildJsBasemapToggleVisibleElements(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsBasemapToggleVisibleElementsGenerated } = await import('./basemapToggleVisibleElements.gb');
    return await buildJsBasemapToggleVisibleElementsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetBasemapToggleVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetBasemapToggleVisibleElementsGenerated } = await import('./basemapToggleVisibleElements.gb');
    return await buildDotNetBasemapToggleVisibleElementsGenerated(jsObject, viewId);
}
