
export async function buildJsSliderVisibleElements(dotNetObject: any): Promise<any> {
    let { buildJsSliderVisibleElementsGenerated } = await import('./sliderVisibleElements.gb');
    return await buildJsSliderVisibleElementsGenerated(dotNetObject);
}     

export async function buildDotNetSliderVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetSliderVisibleElementsGenerated } = await import('./sliderVisibleElements.gb');
    return await buildDotNetSliderVisibleElementsGenerated(jsObject);
}
