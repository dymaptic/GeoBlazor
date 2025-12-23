
export async function buildJsRadioButtonsInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRadioButtonsInputGenerated } = await import('./radioButtonsInput.gb');
    return await buildJsRadioButtonsInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRadioButtonsInput(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetRadioButtonsInputGenerated } = await import('./radioButtonsInput.gb');
    return await buildDotNetRadioButtonsInputGenerated(jsObject, viewId);
}
