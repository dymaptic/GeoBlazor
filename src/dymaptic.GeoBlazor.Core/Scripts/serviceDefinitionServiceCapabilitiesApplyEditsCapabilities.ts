
export async function buildJsServiceDefinitionServiceCapabilitiesApplyEditsCapabilities(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsServiceDefinitionServiceCapabilitiesApplyEditsCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesApplyEditsCapabilities.gb');
    return await buildJsServiceDefinitionServiceCapabilitiesApplyEditsCapabilitiesGenerated(dotNetObject, viewId);
}     

export async function buildDotNetServiceDefinitionServiceCapabilitiesApplyEditsCapabilities(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetServiceDefinitionServiceCapabilitiesApplyEditsCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesApplyEditsCapabilities.gb');
    return await buildDotNetServiceDefinitionServiceCapabilitiesApplyEditsCapabilitiesGenerated(jsObject, viewId);
}
