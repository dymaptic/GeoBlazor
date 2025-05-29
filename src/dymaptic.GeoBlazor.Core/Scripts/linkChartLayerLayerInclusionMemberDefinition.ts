
export async function buildJsLinkChartLayerLayerInclusionMemberDefinition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLinkChartLayerLayerInclusionMemberDefinitionGenerated } = await import('./linkChartLayerLayerInclusionMemberDefinition.gb');
    return await buildJsLinkChartLayerLayerInclusionMemberDefinitionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLinkChartLayerLayerInclusionMemberDefinition(jsObject: any): Promise<any> {
    let { buildDotNetLinkChartLayerLayerInclusionMemberDefinitionGenerated } = await import('./linkChartLayerLayerInclusionMemberDefinition.gb');
    return await buildDotNetLinkChartLayerLayerInclusionMemberDefinitionGenerated(jsObject);
}
