
export async function buildJsBasemapToggleVisibleElements(dotNetObject: any): Promise<any> {
    let { buildJsBasemapToggleVisibleElementsGenerated } = await import('./basemapToggleVisibleElements.gb');
    return await buildJsBasemapToggleVisibleElementsGenerated(dotNetObject);
}     

export async function buildDotNetBasemapToggleVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetBasemapToggleVisibleElementsGenerated } = await import('./basemapToggleVisibleElements.gb');
    return await buildDotNetBasemapToggleVisibleElementsGenerated(jsObject);
}
