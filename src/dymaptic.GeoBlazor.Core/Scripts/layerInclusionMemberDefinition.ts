
export async function buildJsLayerInclusionMemberDefinition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerInclusionMemberDefinitionGenerated } = await import('./layerInclusionMemberDefinition.gb');
    return await buildJsLayerInclusionMemberDefinitionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerInclusionMemberDefinition(jsObject: any): Promise<any> {
    let { buildDotNetLayerInclusionMemberDefinitionGenerated } = await import('./layerInclusionMemberDefinition.gb');
    return await buildDotNetLayerInclusionMemberDefinitionGenerated(jsObject);
}
