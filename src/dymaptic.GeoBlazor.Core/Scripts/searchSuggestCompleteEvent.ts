
export async function buildJsSearchSuggestCompleteEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchSuggestCompleteEventGenerated } = await import('./searchSuggestCompleteEvent.gb');
    return await buildJsSearchSuggestCompleteEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchSuggestCompleteEvent(jsObject: any): Promise<any> {
    let { buildDotNetSearchSuggestCompleteEventGenerated } = await import('./searchSuggestCompleteEvent.gb');
    return await buildDotNetSearchSuggestCompleteEventGenerated(jsObject);
}
