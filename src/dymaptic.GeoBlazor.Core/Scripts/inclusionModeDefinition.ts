
export async function buildJsInclusionModeDefinition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsInclusionModeDefinitionGenerated } = await import('./inclusionModeDefinition.gb');
    return await buildJsInclusionModeDefinitionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetInclusionModeDefinition(jsObject: any): Promise<any> {
    let { buildDotNetInclusionModeDefinitionGenerated } = await import('./inclusionModeDefinition.gb');
    return await buildDotNetInclusionModeDefinitionGenerated(jsObject);
}
