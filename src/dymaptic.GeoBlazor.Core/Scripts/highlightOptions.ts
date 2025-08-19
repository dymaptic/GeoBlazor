
export async function buildJsHighlightOptions(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsHighlightOptionsGenerated } = await import('./highlightOptions.gb');
    return await buildJsHighlightOptionsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetHighlightOptions(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetHighlightOptionsGenerated } = await import('./highlightOptions.gb');
    return await buildDotNetHighlightOptionsGenerated(jsObject, viewId);
}
