
export async function buildJsValuePickerSlider(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsValuePickerSliderGenerated } = await import('./valuePickerSlider.gb');
    return await buildJsValuePickerSliderGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetValuePickerSlider(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetValuePickerSliderGenerated } = await import('./valuePickerSlider.gb');
    return await buildDotNetValuePickerSliderGenerated(jsObject, layerId, viewId);
}
