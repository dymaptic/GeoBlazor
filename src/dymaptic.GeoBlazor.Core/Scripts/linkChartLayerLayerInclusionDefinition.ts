
export async function buildJsLinkChartLayerLayerInclusionDefinition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLinkChartLayerLayerInclusionDefinitionGenerated } = await import('./linkChartLayerLayerInclusionDefinition.gb');
    return await buildJsLinkChartLayerLayerInclusionDefinitionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLinkChartLayerLayerInclusionDefinition(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLinkChartLayerLayerInclusionDefinitionGenerated } = await import('./linkChartLayerLayerInclusionDefinition.gb');
    return await buildDotNetLinkChartLayerLayerInclusionDefinitionGenerated(jsObject, viewId);
}
