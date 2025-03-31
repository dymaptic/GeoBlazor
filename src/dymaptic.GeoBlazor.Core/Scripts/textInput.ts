
export async function buildJsTextInput(dotNetObject: any): Promise<any> {
    let { buildJsTextInputGenerated } = await import('./textInput.gb');
    return await buildJsTextInputGenerated(dotNetObject);
}     

export async function buildDotNetTextInput(jsObject: any): Promise<any> {
    let { buildDotNetTextInputGenerated } = await import('./textInput.gb');
    return await buildDotNetTextInputGenerated(jsObject);
}
