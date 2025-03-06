
export async function buildJsVersionManagementServiceVersionIdentifier(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionManagementServiceVersionIdentifierGenerated } = await import('./versionManagementServiceVersionIdentifier.gb');
    return await buildJsVersionManagementServiceVersionIdentifierGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionManagementServiceVersionIdentifier(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVersionManagementServiceVersionIdentifierGenerated } = await import('./versionManagementServiceVersionIdentifier.gb');
    return await buildDotNetVersionManagementServiceVersionIdentifierGenerated(jsObject, layerId, viewId);
}
