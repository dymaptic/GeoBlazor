
export async function buildJsExecuteResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsExecuteResultGenerated } = await import('./executeResult.gb');
    return await buildJsExecuteResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetExecuteResult(jsObject: any): Promise<any> {
    let { buildDotNetExecuteResultGenerated } = await import('./executeResult.gb');
    return await buildDotNetExecuteResultGenerated(jsObject);
}
