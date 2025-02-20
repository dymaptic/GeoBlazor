export async function buildJsSummaryStatisticsSummaryStatisticsParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSummaryStatisticsSummaryStatisticsParamsGenerated} = await import('./summaryStatisticsSummaryStatisticsParams.gb');
    return await buildJsSummaryStatisticsSummaryStatisticsParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSummaryStatisticsSummaryStatisticsParams(jsObject: any): Promise<any> {
    let {buildDotNetSummaryStatisticsSummaryStatisticsParamsGenerated} = await import('./summaryStatisticsSummaryStatisticsParams.gb');
    return await buildDotNetSummaryStatisticsSummaryStatisticsParamsGenerated(jsObject);
}
