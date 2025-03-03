
export async function buildJsNamedObjectEditResults(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsNamedObjectEditResultsGenerated } = await import('./namedObjectEditResults.gb');
    return await buildJsNamedObjectEditResultsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetNamedObjectEditResults(jsObject: any): Promise<any> {
    let { buildDotNetNamedObjectEditResultsGenerated } = await import('./namedObjectEditResults.gb');
    return await buildDotNetNamedObjectEditResultsGenerated(jsObject);
}
