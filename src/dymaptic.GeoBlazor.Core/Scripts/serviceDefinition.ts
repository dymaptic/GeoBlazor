
export async function buildJsServiceDefinition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsServiceDefinitionGenerated } = await import('./serviceDefinition.gb');
    return await buildJsServiceDefinitionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetServiceDefinition(jsObject: any): Promise<any> {
    let { buildDotNetServiceDefinitionGenerated } = await import('./serviceDefinition.gb');
    return await buildDotNetServiceDefinitionGenerated(jsObject);
}
