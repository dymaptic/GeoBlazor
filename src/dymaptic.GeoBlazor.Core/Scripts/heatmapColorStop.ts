export async function buildJsHeatmapColorStop(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsHeatmapColorStopGenerated} = await import('./heatmapColorStop.gb');
    return await buildJsHeatmapColorStopGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetHeatmapColorStop(jsObject: any): Promise<any> {
    let {buildDotNetHeatmapColorStopGenerated} = await import('./heatmapColorStop.gb');
    return await buildDotNetHeatmapColorStopGenerated(jsObject);
}
