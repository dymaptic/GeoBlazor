
export async function buildJsVersionInfoJSONVersionIdentifier(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionInfoJSONVersionIdentifierGenerated } = await import('./versionInfoJSONVersionIdentifier.gb');
    return await buildJsVersionInfoJSONVersionIdentifierGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionInfoJSONVersionIdentifier(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVersionInfoJSONVersionIdentifierGenerated } = await import('./versionInfoJSONVersionIdentifier.gb');
    return await buildDotNetVersionInfoJSONVersionIdentifierGenerated(jsObject, layerId, viewId);
}
