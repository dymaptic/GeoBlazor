
export async function buildJsDateTimePickerInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDateTimePickerInputGenerated } = await import('./dateTimePickerInput.gb');
    return await buildJsDateTimePickerInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDateTimePickerInput(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDateTimePickerInputGenerated } = await import('./dateTimePickerInput.gb');
    return await buildDotNetDateTimePickerInputGenerated(jsObject, layerId, viewId);
}
