
export async function buildJsSearchViewModelSuggestResponseErrors(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchViewModelSuggestResponseErrorsGenerated } = await import('./searchViewModelSuggestResponseErrors.gb');
    return await buildJsSearchViewModelSuggestResponseErrorsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchViewModelSuggestResponseErrors(jsObject: any): Promise<any> {
    let { buildDotNetSearchViewModelSuggestResponseErrorsGenerated } = await import('./searchViewModelSuggestResponseErrors.gb');
    return await buildDotNetSearchViewModelSuggestResponseErrorsGenerated(jsObject);
}
