
export async function buildJsWFSOperations(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWFSOperationsGenerated } = await import('./wFSOperations.gb');
    return await buildJsWFSOperationsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWFSOperations(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetWFSOperationsGenerated } = await import('./wFSOperations.gb');
    return await buildDotNetWFSOperationsGenerated(jsObject, layerId, viewId);
}
