
export async function buildJsSearchViewModelSuggestResponse(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchViewModelSuggestResponseGenerated } = await import('./searchViewModelSuggestResponse.gb');
    return await buildJsSearchViewModelSuggestResponseGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchViewModelSuggestResponse(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSearchViewModelSuggestResponseGenerated } = await import('./searchViewModelSuggestResponse.gb');
    return await buildDotNetSearchViewModelSuggestResponseGenerated(jsObject, layerId, viewId);
}
