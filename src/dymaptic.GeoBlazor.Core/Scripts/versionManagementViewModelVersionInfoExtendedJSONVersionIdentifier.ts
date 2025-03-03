
export async function buildJsVersionManagementViewModelVersionInfoExtendedJSONVersionIdentifier(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionManagementViewModelVersionInfoExtendedJSONVersionIdentifierGenerated } = await import('./versionManagementViewModelVersionInfoExtendedJSONVersionIdentifier.gb');
    return await buildJsVersionManagementViewModelVersionInfoExtendedJSONVersionIdentifierGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionManagementViewModelVersionInfoExtendedJSONVersionIdentifier(jsObject: any): Promise<any> {
    let { buildDotNetVersionManagementViewModelVersionInfoExtendedJSONVersionIdentifierGenerated } = await import('./versionManagementViewModelVersionInfoExtendedJSONVersionIdentifier.gb');
    return await buildDotNetVersionManagementViewModelVersionInfoExtendedJSONVersionIdentifierGenerated(jsObject);
}
