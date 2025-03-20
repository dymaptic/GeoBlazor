
export async function buildJsServiceDefinitionServiceCapabilitiesSearchCapabilities(dotNetObject: any): Promise<any> {
    let { buildJsServiceDefinitionServiceCapabilitiesSearchCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesSearchCapabilities.gb');
    return await buildJsServiceDefinitionServiceCapabilitiesSearchCapabilitiesGenerated(dotNetObject);
}     

export async function buildDotNetServiceDefinitionServiceCapabilitiesSearchCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetServiceDefinitionServiceCapabilitiesSearchCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesSearchCapabilities.gb');
    return await buildDotNetServiceDefinitionServiceCapabilitiesSearchCapabilitiesGenerated(jsObject);
}
