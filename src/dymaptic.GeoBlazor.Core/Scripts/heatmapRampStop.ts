
export async function buildJsHeatmapRampStop(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHeatmapRampStopGenerated } = await import('./heatmapRampStop.gb');
    return await buildJsHeatmapRampStopGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHeatmapRampStop(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetHeatmapRampStopGenerated } = await import('./heatmapRampStop.gb');
    return await buildDotNetHeatmapRampStopGenerated(jsObject, layerId, viewId);
}
