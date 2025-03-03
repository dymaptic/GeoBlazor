
export async function buildJsServiceDefinitionServiceCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsServiceDefinitionServiceCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilities.gb');
    return await buildJsServiceDefinitionServiceCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetServiceDefinitionServiceCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetServiceDefinitionServiceCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilities.gb');
    return await buildDotNetServiceDefinitionServiceCapabilitiesGenerated(jsObject);
}
