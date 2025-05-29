export async function buildJsSearchResponseResults(dotNetObject: any): Promise<any> {
    let {buildJsSearchResponseResultsGenerated} = await import('./searchResponseResults.gb');
    return await buildJsSearchResponseResultsGenerated(dotNetObject);
}

export async function buildDotNetSearchResponseResults(jsObject: any): Promise<any> {
    let {buildDotNetSearchResponseResultsGenerated} = await import('./searchResponseResults.gb');
    return await buildDotNetSearchResponseResultsGenerated(jsObject);
}
