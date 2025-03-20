
export async function buildJsLayerInclusionDefinition(dotNetObject: any): Promise<any> {
    let { buildJsLayerInclusionDefinitionGenerated } = await import('./layerInclusionDefinition.gb');
    return await buildJsLayerInclusionDefinitionGenerated(dotNetObject);
}     

export async function buildDotNetLayerInclusionDefinition(jsObject: any): Promise<any> {
    let { buildDotNetLayerInclusionDefinitionGenerated } = await import('./layerInclusionDefinition.gb');
    return await buildDotNetLayerInclusionDefinitionGenerated(jsObject);
}
