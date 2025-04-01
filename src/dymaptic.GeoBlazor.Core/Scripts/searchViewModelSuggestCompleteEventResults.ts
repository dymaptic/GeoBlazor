
export async function buildJsSearchViewModelSuggestCompleteEventResults(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchViewModelSuggestCompleteEventResultsGenerated } = await import('./searchViewModelSuggestCompleteEventResults.gb');
    return await buildJsSearchViewModelSuggestCompleteEventResultsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchViewModelSuggestCompleteEventResults(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSearchViewModelSuggestCompleteEventResultsGenerated } = await import('./searchViewModelSuggestCompleteEventResults.gb');
    return await buildDotNetSearchViewModelSuggestCompleteEventResultsGenerated(jsObject, layerId, viewId);
}
