export async function buildJsTraceResultExtend(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTraceResultExtendGenerated } = await import('./traceResultExtend.gb');
    return await buildJsTraceResultExtendGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetTraceResultExtend(jsObject: any): Promise<any> {
    let { buildDotNetTraceResultExtendGenerated } = await import('./traceResultExtend.gb');
    return await buildDotNetTraceResultExtendGenerated(jsObject);
}
