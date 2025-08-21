export async function buildJsSearchResponse(dotNetObject: any): Promise<any> {
    let {buildJsSearchResponseGenerated} = await import('./searchResponse.gb');
    return await buildJsSearchResponseGenerated(dotNetObject);
}

export async function buildDotNetSearchResponse(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetSearchResponseGenerated} = await import('./searchResponse.gb');
    return await buildDotNetSearchResponseGenerated(jsObject, viewId);
}
