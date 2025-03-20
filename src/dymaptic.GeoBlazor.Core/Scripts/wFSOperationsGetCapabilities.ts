
export async function buildJsWFSOperationsGetCapabilities(dotNetObject: any): Promise<any> {
    let { buildJsWFSOperationsGetCapabilitiesGenerated } = await import('./wFSOperationsGetCapabilities.gb');
    return await buildJsWFSOperationsGetCapabilitiesGenerated(dotNetObject);
}     

export async function buildDotNetWFSOperationsGetCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetWFSOperationsGetCapabilitiesGenerated } = await import('./wFSOperationsGetCapabilities.gb');
    return await buildDotNetWFSOperationsGetCapabilitiesGenerated(jsObject);
}
