
export async function buildJsVersionInfoVersionIdentifier(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionInfoVersionIdentifierGenerated } = await import('./versionInfoVersionIdentifier.gb');
    return await buildJsVersionInfoVersionIdentifierGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionInfoVersionIdentifier(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVersionInfoVersionIdentifierGenerated } = await import('./versionInfoVersionIdentifier.gb');
    return await buildDotNetVersionInfoVersionIdentifierGenerated(jsObject, layerId, viewId);
}
