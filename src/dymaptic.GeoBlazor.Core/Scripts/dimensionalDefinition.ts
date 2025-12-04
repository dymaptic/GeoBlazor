
export async function buildJsDimensionalDefinition(dotNetObject: any): Promise<any> {
    let { buildJsDimensionalDefinitionGenerated } = await import('./dimensionalDefinition.gb');
    return await buildJsDimensionalDefinitionGenerated(dotNetObject);
}     

export async function buildDotNetDimensionalDefinition(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetDimensionalDefinitionGenerated } = await import('./dimensionalDefinition.gb');
    return await buildDotNetDimensionalDefinitionGenerated(jsObject, viewId);
}
