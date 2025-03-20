
export async function buildJsCapabilitiesOperations(dotNetObject: any): Promise<any> {
    let { buildJsCapabilitiesOperationsGenerated } = await import('./capabilitiesOperations.gb');
    return await buildJsCapabilitiesOperationsGenerated(dotNetObject);
}     

export async function buildDotNetCapabilitiesOperations(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesOperationsGenerated } = await import('./capabilitiesOperations.gb');
    return await buildDotNetCapabilitiesOperationsGenerated(jsObject);
}
