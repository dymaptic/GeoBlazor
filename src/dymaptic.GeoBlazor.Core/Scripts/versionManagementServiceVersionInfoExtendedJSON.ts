
export async function buildJsVersionManagementServiceVersionInfoExtendedJSON(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionManagementServiceVersionInfoExtendedJSONGenerated } = await import('./versionManagementServiceVersionInfoExtendedJSON.gb');
    return await buildJsVersionManagementServiceVersionInfoExtendedJSONGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionManagementServiceVersionInfoExtendedJSON(jsObject: any): Promise<any> {
    let { buildDotNetVersionManagementServiceVersionInfoExtendedJSONGenerated } = await import('./versionManagementServiceVersionInfoExtendedJSON.gb');
    return await buildDotNetVersionManagementServiceVersionInfoExtendedJSONGenerated(jsObject);
}
