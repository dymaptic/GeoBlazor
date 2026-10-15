
export async function buildJsServiceDefinition(dotNetObject: any): Promise<any> {
    let { buildJsServiceDefinitionGenerated } = await import('./serviceDefinition.gb');
    return await buildJsServiceDefinitionGenerated(dotNetObject);
}     

export async function buildDotNetServiceDefinition(jsObject: any): Promise<any> {
    let { buildDotNetServiceDefinitionGenerated } = await import('./serviceDefinition.gb');
    return await buildDotNetServiceDefinitionGenerated(jsObject);
}
