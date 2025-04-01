
export async function buildJsVersionManagementServiceVersionInfoExtendedJSONVersionIdentifier(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionManagementServiceVersionInfoExtendedJSONVersionIdentifierGenerated } = await import('./versionManagementServiceVersionInfoExtendedJSONVersionIdentifier.gb');
    return await buildJsVersionManagementServiceVersionInfoExtendedJSONVersionIdentifierGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionManagementServiceVersionInfoExtendedJSONVersionIdentifier(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVersionManagementServiceVersionInfoExtendedJSONVersionIdentifierGenerated } = await import('./versionManagementServiceVersionInfoExtendedJSONVersionIdentifier.gb');
    return await buildDotNetVersionManagementServiceVersionInfoExtendedJSONVersionIdentifierGenerated(jsObject, layerId, viewId);
}
