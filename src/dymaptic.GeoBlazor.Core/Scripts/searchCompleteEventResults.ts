
export async function buildJsSearchCompleteEventResults(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchCompleteEventResultsGenerated } = await import('./searchCompleteEventResults.gb');
    return await buildJsSearchCompleteEventResultsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchCompleteEventResults(jsObject: any): Promise<any> {
    let { buildDotNetSearchCompleteEventResultsGenerated } = await import('./searchCompleteEventResults.gb');
    return await buildDotNetSearchCompleteEventResultsGenerated(jsObject);
}
