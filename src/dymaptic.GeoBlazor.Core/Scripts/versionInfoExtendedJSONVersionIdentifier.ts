
export async function buildJsVersionInfoExtendedJSONVersionIdentifier(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionInfoExtendedJSONVersionIdentifierGenerated } = await import('./versionInfoExtendedJSONVersionIdentifier.gb');
    return await buildJsVersionInfoExtendedJSONVersionIdentifierGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionInfoExtendedJSONVersionIdentifier(jsObject: any): Promise<any> {
    let { buildDotNetVersionInfoExtendedJSONVersionIdentifierGenerated } = await import('./versionInfoExtendedJSONVersionIdentifier.gb');
    return await buildDotNetVersionInfoExtendedJSONVersionIdentifierGenerated(jsObject);
}
