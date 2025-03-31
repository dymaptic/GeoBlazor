
export async function buildJsServiceDefinitionServiceCapabilitiesApplyEditsCapabilities(dotNetObject: any): Promise<any> {
    let { buildJsServiceDefinitionServiceCapabilitiesApplyEditsCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesApplyEditsCapabilities.gb');
    return await buildJsServiceDefinitionServiceCapabilitiesApplyEditsCapabilitiesGenerated(dotNetObject);
}     

export async function buildDotNetServiceDefinitionServiceCapabilitiesApplyEditsCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetServiceDefinitionServiceCapabilitiesApplyEditsCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesApplyEditsCapabilities.gb');
    return await buildDotNetServiceDefinitionServiceCapabilitiesApplyEditsCapabilitiesGenerated(jsObject);
}
