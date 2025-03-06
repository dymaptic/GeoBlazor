export async function buildJsSearchViewModelSearchResponseResults(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSearchViewModelSearchResponseResultsGenerated} = await import('./searchViewModelSearchResponseResults.gb');
    return await buildJsSearchViewModelSearchResponseResultsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSearchViewModelSearchResponseResults(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSearchViewModelSearchResponseResultsGenerated} = await import('./searchViewModelSearchResponseResults.gb');
    return await buildDotNetSearchViewModelSearchResponseResultsGenerated(jsObject, layerId, viewId);
}
