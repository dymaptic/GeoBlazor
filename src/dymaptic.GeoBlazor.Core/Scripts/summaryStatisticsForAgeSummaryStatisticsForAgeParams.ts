export async function buildJsSummaryStatisticsForAgeSummaryStatisticsForAgeParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSummaryStatisticsForAgeSummaryStatisticsForAgeParamsGenerated} = await import('./summaryStatisticsForAgeSummaryStatisticsForAgeParams.gb');
    return await buildJsSummaryStatisticsForAgeSummaryStatisticsForAgeParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSummaryStatisticsForAgeSummaryStatisticsForAgeParams(jsObject: any): Promise<any> {
    let {buildDotNetSummaryStatisticsForAgeSummaryStatisticsForAgeParamsGenerated} = await import('./summaryStatisticsForAgeSummaryStatisticsForAgeParams.gb');
    return await buildDotNetSummaryStatisticsForAgeSummaryStatisticsForAgeParamsGenerated(jsObject);
}
