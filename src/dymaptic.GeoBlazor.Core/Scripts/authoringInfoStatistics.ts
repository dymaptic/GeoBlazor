
export async function buildJsAuthoringInfoStatistics(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAuthoringInfoStatisticsGenerated } = await import('./authoringInfoStatistics.gb');
    return await buildJsAuthoringInfoStatisticsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAuthoringInfoStatistics(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetAuthoringInfoStatisticsGenerated } = await import('./authoringInfoStatistics.gb');
    return await buildDotNetAuthoringInfoStatisticsGenerated(jsObject, layerId, viewId);
}
