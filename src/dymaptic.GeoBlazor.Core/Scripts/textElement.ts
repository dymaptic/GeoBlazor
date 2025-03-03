
export async function buildJsTextElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTextElementGenerated } = await import('./textElement.gb');
    return await buildJsTextElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTextElement(jsObject: any): Promise<any> {
    let { buildDotNetTextElementGenerated } = await import('./textElement.gb');
    return await buildDotNetTextElementGenerated(jsObject);
}
