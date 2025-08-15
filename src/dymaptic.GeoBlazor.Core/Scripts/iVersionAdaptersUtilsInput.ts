
export async function buildJsIVersionAdaptersUtilsInput(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIVersionAdaptersUtilsInputGenerated } = await import('./iVersionAdaptersUtilsInput.gb');
    return await buildJsIVersionAdaptersUtilsInputGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIVersionAdaptersUtilsInput(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIVersionAdaptersUtilsInputGenerated } = await import('./iVersionAdaptersUtilsInput.gb');
    return await buildDotNetIVersionAdaptersUtilsInputGenerated(jsObject, viewId);
}
