
export async function buildJsInclusionModeDefinition(dotNetObject: any): Promise<any> {
    let { buildJsInclusionModeDefinitionGenerated } = await import('./inclusionModeDefinition.gb');
    return await buildJsInclusionModeDefinitionGenerated(dotNetObject);
}     

export async function buildDotNetInclusionModeDefinition(jsObject: any): Promise<any> {
    let { buildDotNetInclusionModeDefinitionGenerated } = await import('./inclusionModeDefinition.gb');
    return await buildDotNetInclusionModeDefinitionGenerated(jsObject);
}
