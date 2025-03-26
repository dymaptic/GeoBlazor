
export async function buildJsTraceResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTraceResultGenerated } = await import('./traceResult.gb');
    return await buildJsTraceResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTraceResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTraceResultGenerated } = await import('./traceResult.gb');
    return await buildDotNetTraceResultGenerated(jsObject, layerId, viewId);
}
