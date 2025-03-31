
export async function buildJsBuildingFieldStatistics(dotNetObject: any): Promise<any> {
    let { buildJsBuildingFieldStatisticsGenerated } = await import('./buildingFieldStatistics.gb');
    return await buildJsBuildingFieldStatisticsGenerated(dotNetObject);
}     

export async function buildDotNetBuildingFieldStatistics(jsObject: any): Promise<any> {
    let { buildDotNetBuildingFieldStatisticsGenerated } = await import('./buildingFieldStatistics.gb');
    return await buildDotNetBuildingFieldStatisticsGenerated(jsObject);
}
