export async function buildJsHeatmapStatisticsHeatmapStatisticsParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHeatmapStatisticsHeatmapStatisticsParamsGenerated } = await import('./heatmapStatisticsHeatmapStatisticsParams.gb');
    return await buildJsHeatmapStatisticsHeatmapStatisticsParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetHeatmapStatisticsHeatmapStatisticsParams(jsObject: any): Promise<any> {
    let { buildDotNetHeatmapStatisticsHeatmapStatisticsParamsGenerated } = await import('./heatmapStatisticsHeatmapStatisticsParams.gb');
    return await buildDotNetHeatmapStatisticsHeatmapStatisticsParamsGenerated(jsObject);
}
