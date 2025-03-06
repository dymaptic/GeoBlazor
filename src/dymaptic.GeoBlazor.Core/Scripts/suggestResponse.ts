
export async function buildJsSuggestResponse(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSuggestResponseGenerated } = await import('./suggestResponse.gb');
    return await buildJsSuggestResponseGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSuggestResponse(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSuggestResponseGenerated } = await import('./suggestResponse.gb');
    return await buildDotNetSuggestResponseGenerated(jsObject, layerId, viewId);
}
