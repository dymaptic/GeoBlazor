
export async function buildJsIVersionAdaptersUtilsInput(dotNetObject: any): Promise<any> {
    let { buildJsIVersionAdaptersUtilsInputGenerated } = await import('./iVersionAdaptersUtilsInput.gb');
    return await buildJsIVersionAdaptersUtilsInputGenerated(dotNetObject);
}     

export async function buildDotNetIVersionAdaptersUtilsInput(jsObject: any): Promise<any> {
    let { buildDotNetIVersionAdaptersUtilsInputGenerated } = await import('./iVersionAdaptersUtilsInput.gb');
    return await buildDotNetIVersionAdaptersUtilsInputGenerated(jsObject);
}
