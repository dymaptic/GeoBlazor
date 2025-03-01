
export async function buildJsSearchViewModelSuggestResponseResults(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchViewModelSuggestResponseResultsGenerated } = await import('./searchViewModelSuggestResponseResults.gb');
    return await buildJsSearchViewModelSuggestResponseResultsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchViewModelSuggestResponseResults(jsObject: any): Promise<any> {
    let { buildDotNetSearchViewModelSuggestResponseResultsGenerated } = await import('./searchViewModelSuggestResponseResults.gb');
    return await buildDotNetSearchViewModelSuggestResponseResultsGenerated(jsObject);
}
