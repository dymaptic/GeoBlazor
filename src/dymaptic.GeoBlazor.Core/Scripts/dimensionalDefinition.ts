
export async function buildJsDimensionalDefinition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDimensionalDefinitionGenerated } = await import('./dimensionalDefinition.gb');
    return await buildJsDimensionalDefinitionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDimensionalDefinition(jsObject: any): Promise<any> {
    let { buildDotNetDimensionalDefinitionGenerated } = await import('./dimensionalDefinition.gb');
    return await buildDotNetDimensionalDefinitionGenerated(jsObject);
}
