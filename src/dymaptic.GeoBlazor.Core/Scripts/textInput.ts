
export function buildJsTextInput(dotNetObject: any): any {
    let { buildJsTextInputGenerated } = await import('./textInput.gb');
    return buildJsTextInputGenerated(dotNetObject);
}     

export function buildDotNetTextInput(jsObject: any): any {
    let { buildDotNetTextInputGenerated } = await import('./textInput.gb');
    return buildDotNetTextInputGenerated(jsObject);
}
