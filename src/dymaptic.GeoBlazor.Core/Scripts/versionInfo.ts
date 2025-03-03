
export async function buildJsVersionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionInfoGenerated } = await import('./versionInfo.gb');
    return await buildJsVersionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionInfo(jsObject: any): Promise<any> {
    let { buildDotNetVersionInfoGenerated } = await import('./versionInfo.gb');
    return await buildDotNetVersionInfoGenerated(jsObject);
}
