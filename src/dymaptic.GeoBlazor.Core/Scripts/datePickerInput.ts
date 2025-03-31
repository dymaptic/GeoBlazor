
export async function buildJsDatePickerInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDatePickerInputGenerated } = await import('./datePickerInput.gb');
    return await buildJsDatePickerInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDatePickerInput(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDatePickerInputGenerated } = await import('./datePickerInput.gb');
    return await buildDotNetDatePickerInputGenerated(jsObject, layerId, viewId);
}
