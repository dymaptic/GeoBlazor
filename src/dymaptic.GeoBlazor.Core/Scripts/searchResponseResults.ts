
export async function buildJsSearchResponseResults(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchResponseResultsGenerated } = await import('./searchResponseResults.gb');
    return await buildJsSearchResponseResultsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchResponseResults(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSearchResponseResultsGenerated } = await import('./searchResponseResults.gb');
    return await buildDotNetSearchResponseResultsGenerated(jsObject, layerId, viewId);
}
