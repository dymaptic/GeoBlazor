export async function buildJsSearchResponse(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchResponseGenerated } = await import('./searchResponse.gb');
    return await buildJsSearchResponseGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSearchResponse(jsObject: any): Promise<any> {
    let { buildDotNetSearchResponseGenerated } = await import('./searchResponse.gb');
    return await buildDotNetSearchResponseGenerated(jsObject);
}
