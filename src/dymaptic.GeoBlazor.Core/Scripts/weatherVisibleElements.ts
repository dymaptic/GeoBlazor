
export async function buildJsWeatherVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWeatherVisibleElementsGenerated } = await import('./weatherVisibleElements.gb');
    return await buildJsWeatherVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWeatherVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetWeatherVisibleElementsGenerated } = await import('./weatherVisibleElements.gb');
    return await buildDotNetWeatherVisibleElementsGenerated(jsObject);
}
