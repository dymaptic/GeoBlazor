
export async function buildJsVersionInfoJSON(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionInfoJSONGenerated } = await import('./versionInfoJSON.gb');
    return await buildJsVersionInfoJSONGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionInfoJSON(jsObject: any): Promise<any> {
    let { buildDotNetVersionInfoJSONGenerated } = await import('./versionInfoJSON.gb');
    return await buildDotNetVersionInfoJSONGenerated(jsObject);
}
