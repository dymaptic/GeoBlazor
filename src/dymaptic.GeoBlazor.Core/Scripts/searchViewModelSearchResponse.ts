export async function buildJsSearchViewModelSearchResponse(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSearchViewModelSearchResponseGenerated} = await import('./searchViewModelSearchResponse.gb');
    return await buildJsSearchViewModelSearchResponseGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSearchViewModelSearchResponse(jsObject: any): Promise<any> {
    let {buildDotNetSearchViewModelSearchResponseGenerated} = await import('./searchViewModelSearchResponse.gb');
    return await buildDotNetSearchViewModelSearchResponseGenerated(jsObject);
}
