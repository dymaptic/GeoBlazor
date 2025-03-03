
export async function buildJsValuePickerLabel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsValuePickerLabelGenerated } = await import('./valuePickerLabel.gb');
    return await buildJsValuePickerLabelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetValuePickerLabel(jsObject: any): Promise<any> {
    let { buildDotNetValuePickerLabelGenerated } = await import('./valuePickerLabel.gb');
    return await buildDotNetValuePickerLabelGenerated(jsObject);
}
