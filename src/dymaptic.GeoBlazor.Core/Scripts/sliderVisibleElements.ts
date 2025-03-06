
export async function buildJsSliderVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSliderVisibleElementsGenerated } = await import('./sliderVisibleElements.gb');
    return await buildJsSliderVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSliderVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSliderVisibleElementsGenerated } = await import('./sliderVisibleElements.gb');
    return await buildDotNetSliderVisibleElementsGenerated(jsObject, layerId, viewId);
}
