
export async function buildJsIVersionManagementUtilsInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIVersionManagementUtilsInputGenerated } = await import('./iVersionManagementUtilsInput.gb');
    return await buildJsIVersionManagementUtilsInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIVersionManagementUtilsInput(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetIVersionManagementUtilsInputGenerated } = await import('./iVersionManagementUtilsInput.gb');
    return await buildDotNetIVersionManagementUtilsInputGenerated(jsObject, layerId, viewId);
}
