
export async function buildJsLayerListVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerListVisibleElementsGenerated } = await import('./layerListVisibleElements.gb');
    return await buildJsLayerListVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerListVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLayerListVisibleElementsGenerated } = await import('./layerListVisibleElements.gb');
    return await buildDotNetLayerListVisibleElementsGenerated(jsObject, layerId, viewId);
}
