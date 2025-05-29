
export async function buildJsWFSOperations(dotNetObject: any): Promise<any> {
    let { buildJsWFSOperationsGenerated } = await import('./wFSOperations.gb');
    return await buildJsWFSOperationsGenerated(dotNetObject);
}     

export async function buildDotNetWFSOperations(jsObject: any): Promise<any> {
    let { buildDotNetWFSOperationsGenerated } = await import('./wFSOperations.gb');
    return await buildDotNetWFSOperationsGenerated(jsObject);
}
