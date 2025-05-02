
export async function buildJsISearchResultsSuggestionsSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsISearchResultsSuggestionsSourceGenerated } = await import('./iSearchResultsSuggestionsSource.gb');
    return await buildJsISearchResultsSuggestionsSourceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetISearchResultsSuggestionsSource(jsObject: any): Promise<any> {
    let { buildDotNetISearchResultsSuggestionsSourceGenerated } = await import('./iSearchResultsSuggestionsSource.gb');
    return await buildDotNetISearchResultsSuggestionsSourceGenerated(jsObject);
}
