
export async function buildJsLinkChartLayerInclusionModeDefinition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLinkChartLayerInclusionModeDefinitionGenerated } = await import('./linkChartLayerInclusionModeDefinition.gb');
    return await buildJsLinkChartLayerInclusionModeDefinitionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLinkChartLayerInclusionModeDefinition(jsObject: any): Promise<any> {
    let { buildDotNetLinkChartLayerInclusionModeDefinitionGenerated } = await import('./linkChartLayerInclusionModeDefinition.gb');
    return await buildDotNetLinkChartLayerInclusionModeDefinitionGenerated(jsObject);
}
