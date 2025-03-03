
export async function buildJsWFSOperationsGetCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWFSOperationsGetCapabilitiesGenerated } = await import('./wFSOperationsGetCapabilities.gb');
    return await buildJsWFSOperationsGetCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWFSOperationsGetCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetWFSOperationsGetCapabilitiesGenerated } = await import('./wFSOperationsGetCapabilities.gb');
    return await buildDotNetWFSOperationsGetCapabilitiesGenerated(jsObject);
}
