
export async function buildJsVersionManagementVersionManagementServiceVersionIdentifier(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionManagementVersionManagementServiceVersionIdentifierGenerated } = await import('./versionManagementVersionManagementServiceVersionIdentifier.gb');
    return await buildJsVersionManagementVersionManagementServiceVersionIdentifierGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionManagementVersionManagementServiceVersionIdentifier(jsObject: any): Promise<any> {
    let { buildDotNetVersionManagementVersionManagementServiceVersionIdentifierGenerated } = await import('./versionManagementVersionManagementServiceVersionIdentifier.gb');
    return await buildDotNetVersionManagementVersionManagementServiceVersionIdentifierGenerated(jsObject);
}
