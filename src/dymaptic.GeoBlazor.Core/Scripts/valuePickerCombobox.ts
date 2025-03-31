
export async function buildJsValuePickerCombobox(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsValuePickerComboboxGenerated } = await import('./valuePickerCombobox.gb');
    return await buildJsValuePickerComboboxGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetValuePickerCombobox(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetValuePickerComboboxGenerated } = await import('./valuePickerCombobox.gb');
    return await buildDotNetValuePickerComboboxGenerated(jsObject, layerId, viewId);
}
