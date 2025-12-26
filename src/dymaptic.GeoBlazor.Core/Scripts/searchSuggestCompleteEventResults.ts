
export async function buildJsSearchSuggestCompleteEventResults(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchSuggestCompleteEventResultsGenerated } = await import('./searchSuggestCompleteEventResults.gb');
    return await buildJsSearchSuggestCompleteEventResultsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchSuggestCompleteEventResults(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSearchSuggestCompleteEventResultsGenerated } = await import('./searchSuggestCompleteEventResults.gb');
    return await buildDotNetSearchSuggestCompleteEventResultsGenerated(jsObject, viewId);
}
