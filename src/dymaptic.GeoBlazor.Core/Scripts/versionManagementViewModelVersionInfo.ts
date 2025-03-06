
export async function buildJsVersionManagementViewModelVersionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionManagementViewModelVersionInfoGenerated } = await import('./versionManagementViewModelVersionInfo.gb');
    return await buildJsVersionManagementViewModelVersionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionManagementViewModelVersionInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVersionManagementViewModelVersionInfoGenerated } = await import('./versionManagementViewModelVersionInfo.gb');
    return await buildDotNetVersionManagementViewModelVersionInfoGenerated(jsObject, layerId, viewId);
}
