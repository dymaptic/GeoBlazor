
export async function buildJsServiceDefinitionServiceCapabilities(dotNetObject: any): Promise<any> {
    let { buildJsServiceDefinitionServiceCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilities.gb');
    return await buildJsServiceDefinitionServiceCapabilitiesGenerated(dotNetObject);
}     

export async function buildDotNetServiceDefinitionServiceCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetServiceDefinitionServiceCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilities.gb');
    return await buildDotNetServiceDefinitionServiceCapabilitiesGenerated(jsObject);
}
