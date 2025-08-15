
export async function buildJsTextElement(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsTextElementGenerated } = await import('./textElement.gb');
    return await buildJsTextElementGenerated(dotNetObject, viewId);
}     

export async function buildDotNetTextElement(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetTextElementGenerated } = await import('./textElement.gb');
    return await buildDotNetTextElementGenerated(jsObject, viewId);
}
