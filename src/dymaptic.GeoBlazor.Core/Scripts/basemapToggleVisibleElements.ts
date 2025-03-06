
export async function buildJsBasemapToggleVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBasemapToggleVisibleElementsGenerated } = await import('./basemapToggleVisibleElements.gb');
    return await buildJsBasemapToggleVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBasemapToggleVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetBasemapToggleVisibleElementsGenerated } = await import('./basemapToggleVisibleElements.gb');
    return await buildDotNetBasemapToggleVisibleElementsGenerated(jsObject, layerId, viewId);
}
