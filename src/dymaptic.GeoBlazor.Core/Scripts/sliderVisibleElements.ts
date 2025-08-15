
export async function buildJsSliderVisibleElements(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsSliderVisibleElementsGenerated } = await import('./sliderVisibleElements.gb');
    return await buildJsSliderVisibleElementsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetSliderVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSliderVisibleElementsGenerated } = await import('./sliderVisibleElements.gb');
    return await buildDotNetSliderVisibleElementsGenerated(jsObject, viewId);
}
