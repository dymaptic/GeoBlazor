
export async function buildJsServiceDefinitionServiceCapabilitiesIndexCapabilities(dotNetObject: any): Promise<any> {
    let { buildJsServiceDefinitionServiceCapabilitiesIndexCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesIndexCapabilities.gb');
    return await buildJsServiceDefinitionServiceCapabilitiesIndexCapabilitiesGenerated(dotNetObject);
}     

export async function buildDotNetServiceDefinitionServiceCapabilitiesIndexCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetServiceDefinitionServiceCapabilitiesIndexCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesIndexCapabilities.gb');
    return await buildDotNetServiceDefinitionServiceCapabilitiesIndexCapabilitiesGenerated(jsObject);
}
