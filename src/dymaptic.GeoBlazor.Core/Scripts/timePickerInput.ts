
export async function buildJsTimePickerInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTimePickerInputGenerated } = await import('./timePickerInput.gb');
    return await buildJsTimePickerInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTimePickerInput(jsObject: any): Promise<any> {
    let { buildDotNetTimePickerInputGenerated } = await import('./timePickerInput.gb');
    return await buildDotNetTimePickerInputGenerated(jsObject);
}
