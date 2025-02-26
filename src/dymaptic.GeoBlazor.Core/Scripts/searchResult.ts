
export async function buildJsSearchResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchResultGenerated } = await import('./searchResult.gb');
    return await buildJsSearchResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchResult(jsObject: any): Promise<any> {
    let { buildDotNetSearchResultGenerated } = await import('./searchResult.gb');
    return await buildDotNetSearchResultGenerated(jsObject);
}
