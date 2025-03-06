
export async function buildJsHighlightOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHighlightOptionsGenerated } = await import('./highlightOptions.gb');
    return await buildJsHighlightOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHighlightOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetHighlightOptionsGenerated } = await import('./highlightOptions.gb');
    return await buildDotNetHighlightOptionsGenerated(jsObject, layerId, viewId);
}
