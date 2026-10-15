
export async function buildJsStopsByDates(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStopsByDatesGenerated } = await import('./stopsByDates.gb');
    return await buildJsStopsByDatesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetStopsByDates(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetStopsByDatesGenerated } = await import('./stopsByDates.gb');
    return await buildDotNetStopsByDatesGenerated(jsObject, layerId, viewId);
}
