
export async function buildJsCapabilitiesQueryAttributeBinsSupportedStatistics(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesQueryAttributeBinsSupportedStatisticsGenerated } = await import('./capabilitiesQueryAttributeBinsSupportedStatistics.gb');
    return await buildJsCapabilitiesQueryAttributeBinsSupportedStatisticsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCapabilitiesQueryAttributeBinsSupportedStatistics(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesQueryAttributeBinsSupportedStatisticsGenerated } = await import('./capabilitiesQueryAttributeBinsSupportedStatistics.gb');
    return await buildDotNetCapabilitiesQueryAttributeBinsSupportedStatisticsGenerated(jsObject);
}
