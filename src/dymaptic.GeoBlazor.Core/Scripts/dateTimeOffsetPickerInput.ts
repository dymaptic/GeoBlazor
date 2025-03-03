
export async function buildJsDateTimeOffsetPickerInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDateTimeOffsetPickerInputGenerated } = await import('./dateTimeOffsetPickerInput.gb');
    return await buildJsDateTimeOffsetPickerInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDateTimeOffsetPickerInput(jsObject: any): Promise<any> {
    let { buildDotNetDateTimeOffsetPickerInputGenerated } = await import('./dateTimeOffsetPickerInput.gb');
    return await buildDotNetDateTimeOffsetPickerInputGenerated(jsObject);
}
