
export async function buildJsEditResultsObject(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditResultsObjectGenerated } = await import('./editResultsObject.gb');
    return await buildJsEditResultsObjectGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditResultsObject(jsObject: any): Promise<any> {
    let { buildDotNetEditResultsObjectGenerated } = await import('./editResultsObject.gb');
    return await buildDotNetEditResultsObjectGenerated(jsObject);
}
