
export async function buildJsLayerInclusionDefinition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerInclusionDefinitionGenerated } = await import('./layerInclusionDefinition.gb');
    return await buildJsLayerInclusionDefinitionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerInclusionDefinition(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLayerInclusionDefinitionGenerated } = await import('./layerInclusionDefinition.gb');
    return await buildDotNetLayerInclusionDefinitionGenerated(jsObject, layerId, viewId);
}
