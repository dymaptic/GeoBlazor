
export async function buildJsCapabilitiesOperations(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesOperationsGenerated } = await import('./capabilitiesOperations.gb');
    return await buildJsCapabilitiesOperationsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCapabilitiesOperations(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesOperationsGenerated } = await import('./capabilitiesOperations.gb');
    return await buildDotNetCapabilitiesOperationsGenerated(jsObject);
}
