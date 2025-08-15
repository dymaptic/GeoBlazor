
export async function buildJsInclusionModeDefinition(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsInclusionModeDefinitionGenerated } = await import('./inclusionModeDefinition.gb');
    return await buildJsInclusionModeDefinitionGenerated(dotNetObject, viewId);
}     

export async function buildDotNetInclusionModeDefinition(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetInclusionModeDefinitionGenerated } = await import('./inclusionModeDefinition.gb');
    return await buildDotNetInclusionModeDefinitionGenerated(jsObject, viewId);
}
