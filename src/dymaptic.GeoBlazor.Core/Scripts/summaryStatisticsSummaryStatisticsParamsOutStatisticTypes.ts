
export async function buildJsSummaryStatisticsSummaryStatisticsParamsOutStatisticTypes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSummaryStatisticsSummaryStatisticsParamsOutStatisticTypesGenerated } = await import('./summaryStatisticsSummaryStatisticsParamsOutStatisticTypes.gb');
    return await buildJsSummaryStatisticsSummaryStatisticsParamsOutStatisticTypesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSummaryStatisticsSummaryStatisticsParamsOutStatisticTypes(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSummaryStatisticsSummaryStatisticsParamsOutStatisticTypesGenerated } = await import('./summaryStatisticsSummaryStatisticsParamsOutStatisticTypes.gb');
    return await buildDotNetSummaryStatisticsSummaryStatisticsParamsOutStatisticTypesGenerated(jsObject, viewId);
}
