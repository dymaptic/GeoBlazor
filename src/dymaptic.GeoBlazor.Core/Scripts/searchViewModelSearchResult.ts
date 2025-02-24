export async function buildJsSearchViewModelSearchResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSearchViewModelSearchResultGenerated} = await import('./searchViewModelSearchResult.gb');
    return await buildJsSearchViewModelSearchResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSearchViewModelSearchResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSearchViewModelSearchResultGenerated} = await import('./searchViewModelSearchResult.gb');
    return await buildDotNetSearchViewModelSearchResultGenerated(jsObject, layerId, viewId);
}
