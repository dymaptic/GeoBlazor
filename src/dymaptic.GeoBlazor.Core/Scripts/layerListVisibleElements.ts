
export async function buildJsLayerListVisibleElements(dotNetObject: any): Promise<any> {
    let { buildJsLayerListVisibleElementsGenerated } = await import('./layerListVisibleElements.gb');
    return await buildJsLayerListVisibleElementsGenerated(dotNetObject);
}     

export async function buildDotNetLayerListVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetLayerListVisibleElementsGenerated } = await import('./layerListVisibleElements.gb');
    return await buildDotNetLayerListVisibleElementsGenerated(jsObject);
}
