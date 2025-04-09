
export async function buildJsCIMFilteredFindPathsStatistics(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMFilteredFindPathsStatisticsGenerated } = await import('./cIMFilteredFindPathsStatistics.gb');
    return await buildJsCIMFilteredFindPathsStatisticsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMFilteredFindPathsStatistics(jsObject: any): Promise<any> {
    let { buildDotNetCIMFilteredFindPathsStatisticsGenerated } = await import('./cIMFilteredFindPathsStatistics.gb');
    return await buildDotNetCIMFilteredFindPathsStatisticsGenerated(jsObject);
}
