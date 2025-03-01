
export async function buildJsSearchViewModelSuggestCompleteEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchViewModelSuggestCompleteEventGenerated } = await import('./searchViewModelSuggestCompleteEvent.gb');
    return await buildJsSearchViewModelSuggestCompleteEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchViewModelSuggestCompleteEvent(jsObject: any): Promise<any> {
    let { buildDotNetSearchViewModelSuggestCompleteEventGenerated } = await import('./searchViewModelSuggestCompleteEvent.gb');
    return await buildDotNetSearchViewModelSuggestCompleteEventGenerated(jsObject);
}
