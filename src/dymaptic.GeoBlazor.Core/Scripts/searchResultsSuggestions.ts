
export async function buildJsSearchResultsSuggestions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchResultsSuggestionsGenerated } = await import('./searchResultsSuggestions.gb');
    return await buildJsSearchResultsSuggestionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchResultsSuggestions(jsObject: any): Promise<any> {
    let { buildDotNetSearchResultsSuggestionsGenerated } = await import('./searchResultsSuggestions.gb');
    return await buildDotNetSearchResultsSuggestionsGenerated(jsObject);
}
