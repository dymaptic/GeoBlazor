
export async function buildJsStopsByCount(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStopsByCountGenerated } = await import('./stopsByCount.gb');
    return await buildJsStopsByCountGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetStopsByCount(jsObject: any): Promise<any> {
    let { buildDotNetStopsByCountGenerated } = await import('./stopsByCount.gb');
    return await buildDotNetStopsByCountGenerated(jsObject);
}
