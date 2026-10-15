
export async function buildJsLayerInclusionDefinition(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsLayerInclusionDefinitionGenerated } = await import('./layerInclusionDefinition.gb');
    return await buildJsLayerInclusionDefinitionGenerated(dotNetObject, viewId);
}     

export async function buildDotNetLayerInclusionDefinition(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLayerInclusionDefinitionGenerated } = await import('./layerInclusionDefinition.gb');
    return await buildDotNetLayerInclusionDefinitionGenerated(jsObject, viewId);
}
