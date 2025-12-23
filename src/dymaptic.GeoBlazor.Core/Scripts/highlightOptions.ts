
export async function buildJsHighlightOptions(dotNetObject: any): Promise<any> {
    let { buildJsHighlightOptionsGenerated } = await import('./highlightOptions.gb');
    return await buildJsHighlightOptionsGenerated(dotNetObject);
}     

export async function buildDotNetHighlightOptions(jsObject: any): Promise<any> {
    let { buildDotNetHighlightOptionsGenerated } = await import('./highlightOptions.gb');
    return await buildDotNetHighlightOptionsGenerated(jsObject);
}
