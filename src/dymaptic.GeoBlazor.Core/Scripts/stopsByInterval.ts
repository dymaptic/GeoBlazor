export async function buildJsStopsByInterval(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStopsByIntervalGenerated } = await import('./stopsByInterval.gb');
    return await buildJsStopsByIntervalGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetStopsByInterval(jsObject: any): Promise<any> {
    let { buildDotNetStopsByIntervalGenerated } = await import('./stopsByInterval.gb');
    return await buildDotNetStopsByIntervalGenerated(jsObject);
}
