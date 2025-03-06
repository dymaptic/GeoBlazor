
export async function buildJsValuePickerSliderVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsValuePickerSliderVisibleElementsGenerated } = await import('./valuePickerSliderVisibleElements.gb');
    return await buildJsValuePickerSliderVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetValuePickerSliderVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetValuePickerSliderVisibleElementsGenerated } = await import('./valuePickerSliderVisibleElements.gb');
    return await buildDotNetValuePickerSliderVisibleElementsGenerated(jsObject, layerId, viewId);
}
