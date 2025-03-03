
export async function buildJsVersionManagementViewModelVersionInfoExtendedJSON(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionManagementViewModelVersionInfoExtendedJSONGenerated } = await import('./versionManagementViewModelVersionInfoExtendedJSON.gb');
    return await buildJsVersionManagementViewModelVersionInfoExtendedJSONGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionManagementViewModelVersionInfoExtendedJSON(jsObject: any): Promise<any> {
    let { buildDotNetVersionManagementViewModelVersionInfoExtendedJSONGenerated } = await import('./versionManagementViewModelVersionInfoExtendedJSON.gb');
    return await buildDotNetVersionManagementViewModelVersionInfoExtendedJSONGenerated(jsObject);
}
