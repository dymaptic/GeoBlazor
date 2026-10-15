
export async function buildJsTextElementInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTextElementInputGenerated } = await import('./textElementInput.gb');
    return await buildJsTextElementInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTextElementInput(jsObject: any): Promise<any> {
    let { buildDotNetTextElementInputGenerated } = await import('./textElementInput.gb');
    return await buildDotNetTextElementInputGenerated(jsObject);
}
