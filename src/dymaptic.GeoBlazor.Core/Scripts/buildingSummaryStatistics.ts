
export async function buildJsBuildingSummaryStatistics(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBuildingSummaryStatisticsGenerated } = await import('./buildingSummaryStatistics.gb');
    return await buildJsBuildingSummaryStatisticsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBuildingSummaryStatistics(jsObject: any): Promise<any> {
    let { buildDotNetBuildingSummaryStatisticsGenerated } = await import('./buildingSummaryStatistics.gb');
    return await buildDotNetBuildingSummaryStatisticsGenerated(jsObject);
}
