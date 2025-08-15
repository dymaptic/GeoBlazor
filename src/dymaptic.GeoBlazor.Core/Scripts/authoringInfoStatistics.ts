
export async function buildJsAuthoringInfoStatistics(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsAuthoringInfoStatisticsGenerated } = await import('./authoringInfoStatistics.gb');
    return await buildJsAuthoringInfoStatisticsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetAuthoringInfoStatistics(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetAuthoringInfoStatisticsGenerated } = await import('./authoringInfoStatistics.gb');
    return await buildDotNetAuthoringInfoStatisticsGenerated(jsObject, viewId);
}
