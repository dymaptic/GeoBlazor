
export async function buildJsVersionManagementServiceCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionManagementServiceCapabilitiesGenerated } = await import('./versionManagementServiceCapabilities.gb');
    return await buildJsVersionManagementServiceCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionManagementServiceCapabilities(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVersionManagementServiceCapabilitiesGenerated } = await import('./versionManagementServiceCapabilities.gb');
    return await buildDotNetVersionManagementServiceCapabilitiesGenerated(jsObject, layerId, viewId);
}
