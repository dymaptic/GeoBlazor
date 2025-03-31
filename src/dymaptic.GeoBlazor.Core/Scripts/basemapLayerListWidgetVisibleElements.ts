
export async function buildJsBasemapLayerListWidgetVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBasemapLayerListWidgetVisibleElementsGenerated } = await import('./basemapLayerListWidgetVisibleElements.gb');
    return await buildJsBasemapLayerListWidgetVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBasemapLayerListWidgetVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetBasemapLayerListWidgetVisibleElementsGenerated } = await import('./basemapLayerListWidgetVisibleElements.gb');
    return await buildDotNetBasemapLayerListWidgetVisibleElementsGenerated(jsObject);
}
