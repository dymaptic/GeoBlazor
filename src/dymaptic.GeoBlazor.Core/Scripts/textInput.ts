
export async function buildJsTextInput(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsTextInputGenerated } = await import('./textInput.gb');
    return await buildJsTextInputGenerated(dotNetObject, viewId);
}     

export async function buildDotNetTextInput(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetTextInputGenerated } = await import('./textInput.gb');
    return await buildDotNetTextInputGenerated(jsObject, viewId);
}
