
export async function buildJsLayerInclusionMemberDefinition(dotNetObject: any): Promise<any> {
    let { buildJsLayerInclusionMemberDefinitionGenerated } = await import('./layerInclusionMemberDefinition.gb');
    return await buildJsLayerInclusionMemberDefinitionGenerated(dotNetObject);
}     

export async function buildDotNetLayerInclusionMemberDefinition(jsObject: any): Promise<any> {
    let { buildDotNetLayerInclusionMemberDefinitionGenerated } = await import('./layerInclusionMemberDefinition.gb');
    return await buildDotNetLayerInclusionMemberDefinitionGenerated(jsObject);
}
