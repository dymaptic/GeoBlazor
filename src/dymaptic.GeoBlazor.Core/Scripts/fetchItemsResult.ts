
export async function buildJsFetchItemsResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFetchItemsResultGenerated } = await import('./fetchItemsResult.gb');
    return await buildJsFetchItemsResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFetchItemsResult(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFetchItemsResultGenerated } = await import('./fetchItemsResult.gb');
    return await buildDotNetFetchItemsResultGenerated(jsObject, viewId);
}
