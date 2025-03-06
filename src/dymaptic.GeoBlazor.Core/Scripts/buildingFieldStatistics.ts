
export async function buildJsBuildingFieldStatistics(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBuildingFieldStatisticsGenerated } = await import('./buildingFieldStatistics.gb');
    return await buildJsBuildingFieldStatisticsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBuildingFieldStatistics(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetBuildingFieldStatisticsGenerated } = await import('./buildingFieldStatistics.gb');
    return await buildDotNetBuildingFieldStatisticsGenerated(jsObject, layerId, viewId);
}
