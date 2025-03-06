
export async function buildJsValuePickerVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsValuePickerVisibleElementsGenerated } = await import('./valuePickerVisibleElements.gb');
    return await buildJsValuePickerVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetValuePickerVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetValuePickerVisibleElementsGenerated } = await import('./valuePickerVisibleElements.gb');
    return await buildDotNetValuePickerVisibleElementsGenerated(jsObject, layerId, viewId);
}
