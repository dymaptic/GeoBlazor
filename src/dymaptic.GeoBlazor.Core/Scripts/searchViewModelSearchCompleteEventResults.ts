export async function buildJsSearchViewModelSearchCompleteEventResults(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSearchViewModelSearchCompleteEventResultsGenerated} = await import('./searchViewModelSearchCompleteEventResults.gb');
    return await buildJsSearchViewModelSearchCompleteEventResultsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSearchViewModelSearchCompleteEventResults(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSearchViewModelSearchCompleteEventResultsGenerated} = await import('./searchViewModelSearchCompleteEventResults.gb');
    return await buildDotNetSearchViewModelSearchCompleteEventResultsGenerated(jsObject, layerId, viewId);
}
