
export async function buildJsHeatmapRampStop(dotNetObject: any): Promise<any> {
    let { buildJsHeatmapRampStopGenerated } = await import('./heatmapRampStop.gb');
    return await buildJsHeatmapRampStopGenerated(dotNetObject);
}     

export async function buildDotNetHeatmapRampStop(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetHeatmapRampStopGenerated } = await import('./heatmapRampStop.gb');
    return await buildDotNetHeatmapRampStopGenerated(jsObject, viewId);
}
