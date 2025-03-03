
export async function buildJsKnowledgeGraphSublayerCapabilitiesQuerySupportedSpatialAggregationStatistics(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsKnowledgeGraphSublayerCapabilitiesQuerySupportedSpatialAggregationStatisticsGenerated } = await import('./knowledgeGraphSublayerCapabilitiesQuerySupportedSpatialAggregationStatistics.gb');
    return await buildJsKnowledgeGraphSublayerCapabilitiesQuerySupportedSpatialAggregationStatisticsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetKnowledgeGraphSublayerCapabilitiesQuerySupportedSpatialAggregationStatistics(jsObject: any): Promise<any> {
    let { buildDotNetKnowledgeGraphSublayerCapabilitiesQuerySupportedSpatialAggregationStatisticsGenerated } = await import('./knowledgeGraphSublayerCapabilitiesQuerySupportedSpatialAggregationStatistics.gb');
    return await buildDotNetKnowledgeGraphSublayerCapabilitiesQuerySupportedSpatialAggregationStatisticsGenerated(jsObject);
}
