
export async function buildJsSuggestResponseResults(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSuggestResponseResultsGenerated } = await import('./suggestResponseResults.gb');
    return await buildJsSuggestResponseResultsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSuggestResponseResults(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSuggestResponseResultsGenerated } = await import('./suggestResponseResults.gb');
    return await buildDotNetSuggestResponseResultsGenerated(jsObject, layerId, viewId);
}
