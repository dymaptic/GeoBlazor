
export async function buildJsLayerListVisibleElements(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsLayerListVisibleElementsGenerated } = await import('./layerListVisibleElements.gb');
    return await buildJsLayerListVisibleElementsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetLayerListVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLayerListVisibleElementsGenerated } = await import('./layerListVisibleElements.gb');
    return await buildDotNetLayerListVisibleElementsGenerated(jsObject, viewId);
}
