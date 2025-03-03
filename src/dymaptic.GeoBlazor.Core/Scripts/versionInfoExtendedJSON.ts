
export async function buildJsVersionInfoExtendedJSON(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionInfoExtendedJSONGenerated } = await import('./versionInfoExtendedJSON.gb');
    return await buildJsVersionInfoExtendedJSONGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionInfoExtendedJSON(jsObject: any): Promise<any> {
    let { buildDotNetVersionInfoExtendedJSONGenerated } = await import('./versionInfoExtendedJSON.gb');
    return await buildDotNetVersionInfoExtendedJSONGenerated(jsObject);
}
