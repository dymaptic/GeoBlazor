
export async function buildJsLayerInclusionMemberDefinition(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsLayerInclusionMemberDefinitionGenerated } = await import('./layerInclusionMemberDefinition.gb');
    return await buildJsLayerInclusionMemberDefinitionGenerated(dotNetObject, viewId);
}     

export async function buildDotNetLayerInclusionMemberDefinition(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLayerInclusionMemberDefinitionGenerated } = await import('./layerInclusionMemberDefinition.gb');
    return await buildDotNetLayerInclusionMemberDefinitionGenerated(jsObject, viewId);
}
