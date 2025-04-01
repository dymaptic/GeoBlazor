
export async function buildJsBuildingSummaryStatistics(dotNetObject: any): Promise<any> {
    let { buildJsBuildingSummaryStatisticsGenerated } = await import('./buildingSummaryStatistics.gb');
    return await buildJsBuildingSummaryStatisticsGenerated(dotNetObject);
}     

export async function buildDotNetBuildingSummaryStatistics(jsObject: any): Promise<any> {
    let { buildDotNetBuildingSummaryStatisticsGenerated } = await import('./buildingSummaryStatistics.gb');
    return await buildDotNetBuildingSummaryStatisticsGenerated(jsObject);
}
