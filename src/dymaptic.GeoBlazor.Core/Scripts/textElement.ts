
export async function buildJsTextElement(dotNetObject: any): Promise<any> {
    let { buildJsTextElementGenerated } = await import('./textElement.gb');
    return await buildJsTextElementGenerated(dotNetObject);
}     

export async function buildDotNetTextElement(jsObject: any): Promise<any> {
    let { buildDotNetTextElementGenerated } = await import('./textElement.gb');
    return await buildDotNetTextElementGenerated(jsObject);
}
