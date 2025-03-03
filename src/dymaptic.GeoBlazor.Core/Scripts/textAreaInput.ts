
export async function buildJsTextAreaInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTextAreaInputGenerated } = await import('./textAreaInput.gb');
    return await buildJsTextAreaInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTextAreaInput(jsObject: any): Promise<any> {
    let { buildDotNetTextAreaInputGenerated } = await import('./textAreaInput.gb');
    return await buildDotNetTextAreaInputGenerated(jsObject);
}
