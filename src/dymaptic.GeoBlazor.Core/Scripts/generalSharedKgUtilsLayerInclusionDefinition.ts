
export async function buildJsGeneralSharedKgUtilsLayerInclusionDefinition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeneralSharedKgUtilsLayerInclusionDefinitionGenerated } = await import('./generalSharedKgUtilsLayerInclusionDefinition.gb');
    return await buildJsGeneralSharedKgUtilsLayerInclusionDefinitionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeneralSharedKgUtilsLayerInclusionDefinition(jsObject: any): Promise<any> {
    let { buildDotNetGeneralSharedKgUtilsLayerInclusionDefinitionGenerated } = await import('./generalSharedKgUtilsLayerInclusionDefinition.gb');
    return await buildDotNetGeneralSharedKgUtilsLayerInclusionDefinitionGenerated(jsObject);
}
