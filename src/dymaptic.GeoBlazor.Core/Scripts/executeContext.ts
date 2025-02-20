export async function buildJsExecuteContext(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsExecuteContextGenerated} = await import('./executeContext.gb');
    return await buildJsExecuteContextGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetExecuteContext(jsObject: any): Promise<any> {
    let {buildDotNetExecuteContextGenerated} = await import('./executeContext.gb');
    return await buildDotNetExecuteContextGenerated(jsObject);
}
