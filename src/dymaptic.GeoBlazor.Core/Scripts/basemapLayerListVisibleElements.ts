
export async function buildJsBasemapLayerListVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBasemapLayerListVisibleElementsGenerated } = await import('./basemapLayerListVisibleElements.gb');
    return await buildJsBasemapLayerListVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBasemapLayerListVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetBasemapLayerListVisibleElementsGenerated } = await import('./basemapLayerListVisibleElements.gb');
    return await buildDotNetBasemapLayerListVisibleElementsGenerated(jsObject, layerId, viewId);
}
