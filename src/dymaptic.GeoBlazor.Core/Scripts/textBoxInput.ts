
export async function buildJsTextBoxInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTextBoxInputGenerated } = await import('./textBoxInput.gb');
    return await buildJsTextBoxInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTextBoxInput(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTextBoxInputGenerated } = await import('./textBoxInput.gb');
    return await buildDotNetTextBoxInputGenerated(jsObject, layerId, viewId);
}
