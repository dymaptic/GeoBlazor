
export async function buildJsTraceItem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTraceItemGenerated } = await import('./traceItem.gb');
    return await buildJsTraceItemGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTraceItem(jsObject: any): Promise<any> {
    let { buildDotNetTraceItemGenerated } = await import('./traceItem.gb');
    return await buildDotNetTraceItemGenerated(jsObject);
}
